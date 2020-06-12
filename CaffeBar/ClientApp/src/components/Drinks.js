import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button } from 'reactstrap'

export default function Drinks() {

    const [drinks, setDrinks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [newTitle, setNewTitle] = useState('');
    const [newPrice, setNewPrice] = useState(0);
    const [newTaxRate, setNewTaxRate] = useState(0);
    const [editTitle, setEditTitle] = useState('');
    const [editPrice, setEditPrice] = useState(0);
    const [editTax, setEditTax] = useState(0);
    const [editAvail, setEditAvail] = useState(0);
    const [selectedDrink, setSelectedDrink] = useState({ drinkId: 0, title: "Drink", price: 0, taxRate: 1, available: 0, count: 0, totalDrink: 0 });

    useEffect(() => {
        getDrinks();
    }, [])

    const getDrinks = () => {
        axios.get("http://localhost:59963/api/drinks").then((response) => {
            setDrinks(response.data)
            console.log(JSON.stringify(response.data));
            setLoading(false);
        }).catch((error) => { console.log(error) })
    }

    const deleteDrink = (drink) => {
        let id = drink.drinkId;
        setDrinks(drinks.filter(drink => drink.drinkId !== id));
        axios.delete("http://localhost:59963/api/drinks/delete/" + drink.drinkId).then((response) => {
            alert(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const addDrink = () => {
        let check = new RegExp("^[A-Za-z0-9.' ]+$");
        let data = {
            "Title": newTitle,
            "Price": Number(newPrice),
            "TaxRate": Number(newTaxRate)
        }
        if (newPrice < 0.5 || newTaxRate < 1 || newTitle.length < 3 || !check.test(newTitle)) {
            alert("Inputs are invalid.");
            return;
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/drinks/create",
            data
        }).then((response) => {
            getDrinks();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })

    }

    const editDrink = () => {
        let check = new RegExp("^[A-Za-z0-9.' ]+$");
        let data = {
            "Title": editTitle,
            "Price": Number(editPrice),
            "TaxRate": Number(editTax),
            "Available": Number(editAvail)
        }
        if (editPrice < 0.5 || editTax < 1 || editTitle.length < 3 || editAvail < 0 || !check.test(editTitle)) {
            alert("Inputs are invalid.");
            return;
        }
        axios.request({
            method: 'PUT',
            url: "http://localhost:59963/api/drinks/edit/" + selectedDrink.drinkId,
            data
        }).then((response) => {
            getDrinks();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }


    const selectDrink = (drink) => {
        setSelectedDrink(drink);
        setEditTitle(drink.title);
        setEditPrice(drink.price);
        setEditTax(drink.taxRate);
        setEditAvail(drink.available);
    }

    return (
        <div className="row">
            <div className="col" style={{ marginRight: "4%" }}>
                <h4>Add new</h4>
                <form>
                    <div className="form-group">
                        <label>Title</label>
                        <input type="text" className="form-control" placeholder="Title" onChange={e => setNewTitle(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Price</label>
                        <input type="number" className="form-control" placeholder="Price" onChange={e => setNewPrice(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Tax rate</label>
                        <input type="number" className="form-control" placeholder="Tax rate" onChange={e => setNewTaxRate(e.target.value)} />
                    </div>
                    <Button onClick={() => addDrink()}>Submit</Button>
                </form>


            </div>
            {loading ? <h1>Loading</h1> :
                <div className="row">
                    <h4 align="center">Drink List</h4>
                    <table className="table table-striped" style={{ marginTop: 10 }}>
                        <thead>
                            <tr>
                                <th>Title</th>
                                <th>Price (EUR)</th>
                                <th>Tax rate</th>
                                <th>Available</th>
                                <th colSpan="4">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {drinks.map(drink => {
                                return <tr key={drink.drinkId}>
                                    <td>
                                        {drink.title}
                                    </td>
                                    <td>
                                        {drink.price}
                                    </td>
                                    <td>
                                        {drink.taxRate}
                                    </td>
                                    <td>
                                        {drink.available}
                                    </td>
                                    <td>
                                        <button type="button" className="btn btn-warning" onClick={() => selectDrink(drink)} >Edit</button>
                                    </td>
                                    <td>
                                        <button type="button" onClick={() => deleteDrink(drink)} className="btn btn-danger">Delete</button>
                                    </td>
                                </tr>
                            })}
                        </tbody>
                    </table>
                </div>}
            <div className="col" style={{ marginLeft: "4%" }}>
                <h4>Edit drink</h4>
                <form>
                    <div className="form-group">
                        <label>Title</label>
                        <input type="text" className="form-control" placeholder="Title" onChange={e => setEditTitle(e.target.value)} value={editTitle} />
                    </div>
                    <div className="form-group">
                        <label>Price</label>
                        <input type="number" className="form-control" placeholder="Price" onChange={e => setEditPrice(e.target.value)} value={editPrice} />
                    </div>
                    <label>Tax rate</label>
                    <input type="number" className="form-control" placeholder="Tax rate" onChange={e => setEditTax(e.target.value)} value={editTax} />
                    <div className="form-group">
                        <label>Available</label>
                        <input type="number" className="form-control" onChange={e => setEditAvail(e.target.value)} value={editAvail} />
                    </div>
                    <Button onClick={() => editDrink()} >Finish</Button>
                </form>
            </div>
        </div>
    );
}
