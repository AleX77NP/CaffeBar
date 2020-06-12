import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button } from 'reactstrap'
import Modal from 'react-modal'
import Loader from 'react-loader-spinner'
Modal.setAppElement("#root");

export default function Tables() {

    const [tables, setTables] = useState([]);
    const [guests, setGuests] = useState([]);
    const [loading, setLoading] = useState(true);
    const [newPersons, setNewPersons] = useState(0);
    const [newRes, setNewRes] = useState('No');
    const [newResTime, setNewResTime] = useState('No time');
    const [newResName, setNewResName] = useState('No name');
    const [guestTable, setGuestTable] = useState({ tableId: 0, marking: "00", title: "Table 00", taken: false });
    const [billDrinks, setBillDrinks] = useState([]);
    const [drinks, setDrinks] = useState([]);
    const [waiters, setWaiters] = useState([]);
    const [billTable, setBillTable] = useState({ tableId: 0, marking: "00", title: "Table 00", taken: false });
    const [billWaiter, setBillWaiter] = useState({waiterId:0, name: "Aleksandar", surname:"Milanovic", age:21, salary:200, phone: "062270473", bills:[]});
    const [total, setTotal] = useState(0);
    const [modal, setModal] = useState(false);
    const [guestsToSee, setGuestsToSee] = useState(null);


    useEffect(() => {
        getAll();
    }, [])

    useEffect(() => {
        addTotals();
    }, [billDrinks])

    const guestsShow = (table) => {
        try {
            let guestsTable = guests.find(x => x.tableId === table.tableId);
            if (guestsTable === undefined) {
                alert("This table has no guests.");
                return
            }
            else {
                setGuestsToSee(guestsTable);
                console.log(JSON.stringify(guestsTable));
            }
        }
        catch (e) {
            alert("This table has no guests yet.");
            return;
        }
    }

    const selectGuestTable = (table) => {
        if (table.taken) {
            alert("Table already has guest(s).");
            return;
        }
        setGuestTable(table);
    }

    const getAll = async () => {
        await getGuests();
        await getTables();
        await getDrinks();
        await getWaiters();
        setLoading(false);
    }

    const getTables =async () => {
        axios.get("http://localhost:59963/api/tables").then((response) => {
            setTables(response.data)
            console.log(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const getGuests = async () => {
        axios.get("http://localhost:59963/api/guests").then((response) => {
            setGuests(response.data)
            console.log(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const getDrinks = async () => {
        axios.get("http://localhost:59963/api/drinks").then((response) => {
            setDrinks(response.data)
            console.log(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const getWaiters = async () => {
        axios.get("http://localhost:59963/api/waiters").then((response) => {
            setWaiters(response.data)
            console.log(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const tableForBill = (table) => {
        if (!table.taken) {
            alert("This table has no guests.");
            return;
        }
        setBillDrinks([]);
        setBillTable(table);
    }

    const addGuests = () => {
        let check = new RegExp("^[A-Za-z0-9: ]+$");
        if (newPersons < 1 || !check.test(newResName) || !check.test(newResTime)) {
            alert("Inputs are invalid.");
            return;
        }
        let data = {
            "NumOfPersons": Number(newPersons),
            "Reservation": newRes,
            "ReservationTime": newResTime,
            "ReservationName": newResName,
            "TableId": guestTable.tableId
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/guests/create",
            data
        }).then((response) => {
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })

        takenTable();

    }
    const takenTable = () => {
        let data = {
            "Marking": guestTable.marking,
            "Title": guestTable.title,
            "Taken": true
        }
        axios.request({
            method: 'PUT',
            url: "http://localhost:59963/api/tables/edit/" + guestTable.tableId,
            data
        }).then((response) => {
            getTables();
            getGuests();
            console.log(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }

    const freeTable = () => {
        let data = {
            "Marking": billTable.marking,
            "Title": billTable.title,
            "Taken": false
        }
        axios.request({
            method: 'PUT',
            url: "http://localhost:59963/api/tables/edit/" + billTable.tableId,
            data
        }).then((response) => {
            getTables();
            console.log(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }

    const selectWaiter = (e) => {
        let waiter = JSON.parse(e.target.value);
        console.log(waiter);
        setBillWaiter(waiter);

    }

    const saveBill = () => {
        if (billWaiter === null || billDrinks.length === 0 || billTable.tableId === 0) {
            alert("Waiter, table and drink(s) must be selected.");
            return;
        }
        let date = new Date().toLocaleString();
        let data = {
            "DateAndTime": date,
            "TotalPrice": Number(total),
            "TableId": billTable.tableId,
            "WaiterId": billWaiter.waiterId
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/bills/create",
            data
        }).then((response) => {
            removeGuests(billTable.tableId);
            freeTable();
            getGuests();
            setGuestsToSee(null);
            let bill = response.data.billId;
            billDrinks.forEach(drink => {
                newBDrink(bill, drink.drinkId, drink.count);
            })
            alert("Bill added.");
        }).catch((error) => { alert("Something went wrong."); console.log(error); })

    }

    const newBDrink = (bill, drink, count) => {
        let data = {
            "BillId": Number(bill),
            "DrinkId": Number(drink),
            "DrinkCount" : Number(count)
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/billdrinks/create",
            data
        }).then(response => {
            console.log(JSON.stringify(response.data));
        }).catch(error => console.log(JSON.stringify(error)));
    }

    const removeGuests = (id) => {
        axios.delete("http://localhost:59963/api/guests/delete/" + id).then((response) => {
            console.log(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const selectDrink = (drink) => {
            let isIn = false;
            if (drink.available === 0) {
                alert("Drink is not available at the moment.");
                return;
            }
            let oldDrinks = [...billDrinks];
            for (let item of oldDrinks) {
                if (item.drinkId === drink.drinkId) {
                    isIn = true;
                    let chosen = item;
                    chosen.count++;
                    chosen.totalDrink = chosen.price * chosen.count;
                    setBillDrinks([...oldDrinks])
                }
            }
        if (!isIn) {
            drink.count = 1;
            drink.totalDrink = drink.price;
            setBillDrinks(billDrinks => [...billDrinks, drink]);
        }
    }

    const addTotals = () => {
        let totalAll = 0;
        billDrinks.forEach(bd => totalAll += bd.totalDrink);
        setTotal(totalAll);
    }

    return (
        <div className="row">
            <div className="col">
                <h4>Add guest(s)</h4>
                <form>
                    <div className="form-group">
                        <label>Table</label>
                        <input type="text" className="form-control" placeholder="Table" value={guestTable.title} readOnly={true} />
                    </div>
                    <div className="form-group">
                        <label>Persons</label>
                        <input type="number" className="form-control" placeholder="Persons" onChange={e => setNewPersons(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Reservation</label>
                        <select className="form-control" onChange={e => setNewRes(e.target.value)}>
                            <option>Yes</option>
                            <option>No</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Reservation time</label>
                        <input type="text" className="form-control" placeholder="Time" onChange={e => setNewResTime(e.target.value)} value={newResTime} />
                    </div>
                    <div className="form-group">
                        <label>Reservation name</label>
                        <input type="text" className="form-control" placeholder="Name" onChange={e => setNewResName(e.target.value)} value={newResName} />
                    </div>
                    <Button onClick={() => addGuests()} >Save</Button>
                </form>
                <li className="list-group-item" key={guestsToSee ? guestsToSee.guestId : 'gts'} style={{ visibility: guestsToSee ? 'visible' : 'hidden', marginTop: '5%' }} >
                    <div className="cart-item" style={{ fontSize: 'small' }}>
                        <span style={{ fontStyle: 'larger' }}>Persons: {guestsToSee !== null ? guestsToSee.numOfPersons : '0'}</span><br />
                        <span style={{ fontStyle: 'larger' }}>Reservation: {guestsToSee !== null ? guestsToSee.reservation : 'No'}</span><br />
                        <span>Name: {guestsToSee !== null ? guestsToSee.reservationName : 'No name'} </span><br />
                              <span>Time: {guestsToSee!==null? guestsToSee.reservationTime : 'No time'}</span>
                </div></li>
            </div>
            {loading ? <h1>Loading</h1> :
                    <div className="col-md-8">
                    <div className="row">
                        {tables.map(table => {
                            return <div className="col-md-4" key={table.tableId}>
                                <div className="card mb-4 shadow-sm">
                                    <img className="bd-placeholder-img card-img-top" width="100%" onClick={() => guestsShow(table)} style={{ cursor: 'pointer' }}
                                        src={table.taken ? require('../images/takenTable.png') : require('../images/freeTable.png')} alt="table" />
                                    <div className="card-body">
                                        <p className="card-text font-weight-bold" style={{ textAlign: 'center' }}>{table.title}</p>
                                        <div className="d-flex justify-content-between align-items-center">
                                            <div className="btn-group" style={{ justifyContent: 'center' }}>
                                                <button type="button"
                                                    className="btn btn-sm btn-danger product-btn" onClick={() => tableForBill(table)} >Invoice bill</button>
                                                <button type="button" onClick={() => selectGuestTable(table)} className="btn btn-sm btn-outline-secondary product-btn">Add guest(s)</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div> })}
                    </div></div>}
        
            <div className="col">
                <h4>New bill</h4>
                <form>
                    <div className="form-group">
                        <label>Table</label>
                        <input type="text" className="form-control" placeholder="Table" value={billTable.title} readOnly={true} />
                    </div>
                    <div className="form-group">
                        <label>Waiter</label>
                        <select className="form-control" onChange={e => selectWaiter(e)}>
                            {
                                waiters.map(waiter => <option key={waiter.waiterId} value={JSON.stringify(waiter)}>{waiter.name} {waiter.surname}</option>)
                            }
                        </select>
                    </div>
                </form>
                <button className="btn btn-info" style={{ marginTop: '2%' }} onClick={() => setModal(true)}>Choose drinks</button>
                <h5 style={{ marginTop: '10%', marginBottom: '10%' }}>Drinks</h5>
                <ul className="list-group">
                    {
                        billDrinks.map(item => <li className="list-group-item" key={item.drinkId}><div className="cart-item" style={{ fontSize: 'small' }}>
                            <span style={{ fontStyle: 'larger' }}>{item.title}</span> x <span>{item.count} </span>total:
                              <strong> {item.totalDrink} EUR</strong>
                      </div></li>)
                    }
                    <li className="list-group-item active" style={{ visibility: modal? 'hidden': 'visible' }}>
                        Bill total: {total} EUR
                        </li>
                </ul>
                <button className="btn btn-success" style={{ marginTop: '8%' }} onClick={() => saveBill()} >Invoice</button>
                <Modal isOpen={modal}
                    onRequestClose={() => setModal(false)}
                >
                    <div className="row">
                        {
                            drinks.map(drink => <div key={drink.drinkId} className="col-md-2">
                                <div className="card" style={{ marginBottom: '3%' }}>
                                        <div className="card-body">
                                        <h6 className="card-title">{drink.title} </h6>
                                        <p className="card-text"><strong>{drink.price} EUR</strong></p>
                                        <button className="btn btn-primary" onClick={() => selectDrink(drink)}>Add to bill</button>
                                        </div>
                                </div>
                        </div>)
                        }
                        </div>
                </Modal>
            </div>
            </div>
        );
  
}
