import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button } from 'reactstrap'

export default function Waiters() {

    const [waiters, setWaiters] = useState([]);
    const [loading, setLoading] = useState(true);
    const [newName, setNewName] = useState('');
    const [newSurname, setNewSurname] = useState('');
    const [newAge, setNewAge] = useState(0);
    const [newSalary, setNewSalary] = useState('');
    const [newPhone, setNewPhone] = useState('');
    const [editName, setEditName] = useState('');
    const [editSurname, setEditSurname] = useState('');
    const [editAge, setEditAge] = useState(20);
    const [editSalary, setEditSalary] = useState(200);
    const [editPhone, setEditPhone] = useState('');
    const [selectedWaiter, setSelectedWaiter] = useState({ waiterId: 0, name: "Waiter", surname: "Waiter", age: 20, salary: 200, phone: "060000000" });

    useEffect(() => {
        getWaiters();
    }, [])

    const getWaiters = () => {
        axios.get("http://localhost:59963/api/waiters").then((response) => {
            setWaiters(response.data)
            console.log(JSON.stringify(response.data));
            setLoading(false);
        }).catch((error) => { console.log(error) })
    }

    const deleteWaiter = (waiter) => {
        let id = waiter.waiterId;
        setWaiters(waiters.filter(waiter => waiter.waiterId !== id));
        axios.delete("http://localhost:59963/api/waiters/delete/" + waiter.waiterId).then((response) => {
            alert(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const addWaiter = () => {
        let check = new RegExp("^[A-Za-z ]+$");
        let data = {
            "Name": newName,
            "Surname": newSurname,
            "Age": Number(newAge),
            "Salary": Number(newSalary),
            "Phone": newPhone
        }
        if (Number(newAge) < 17 || newName.length < 3 || newSurname.length < 3 || !check.test(newName) || !check.test(newSurname)) {
            alert("Input values are not valid.");
            return;
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/waiters/create",
            data
        }).then((response) => {
            getWaiters();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
      
    }

    const editWaiter = () => {
        let check = new RegExp("^[A-Za-z ]+$");
        let data = {
            "Name": editName,
            "Surname": editSurname,
            "Age": Number(editAge),
            "Salary": Number(editSalary),
            "Phone": editPhone
        }
        if (Number(editAge) < 17 || editName.length < 3 || editSurname.length < 3 || !check.test(editName) || !check.test(editSurname)) {
            alert("Input values are not valid.");
            return;
        }
        axios.request({
            method: 'PUT',
            url: "http://localhost:59963/api/waiters/edit/" + selectedWaiter.waiterId,
            data
        }).then((response) => {
            getWaiters();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }


    const selectWaiter = (waiter) => {
        setSelectedWaiter(waiter);
        setEditName(waiter.name);
        setEditSurname(waiter.surname);
        setEditAge(waiter.age);
        setEditSalary(waiter.salary);
        setEditPhone(waiter.phone); 
    }
    
    return (
        <div className="row">
            <div className="col" style={{ marginRight: "4%"}}>
                <h4>Add new</h4>
                <form>
                        <div className="form-group">
                        <label>First name</label>
                        <input type="text" className="form-control" placeholder="First name" onChange={e => setNewName(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Last name</label>
                        <input type="text" className="form-control" placeholder="Last name" onChange={e => setNewSurname(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Age</label>
                        <input type="number" className="form-control" placeholder="Age" onChange={e => setNewAge(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Salary</label>
                        <select className="form-control" onChange={e => setNewSalary(e.target.value)}>
                            <option>100</option>
                            <option>200</option>
                            <option>250</option>
                            <option>300</option>
                            <option>350</option>
                            <option>400</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Phone number</label>
                        <input type="text" className="form-control" placeholder="Phone number" onChange={e => setNewPhone(e.target.value)} />
                    </div>
                   
                    <Button onClick={() => addWaiter()}>Submit</Button>
                </form>
                
                       
            </div>
            {loading ? <h1>Loading</h1> :
                <div className="row">
                    <h4 align="center">Waiter List</h4>  
                        <table className="table table-striped" style={{ marginTop: 10 }}>
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Surname</th>
                                    <th>Age</th>
                                    <th>Salary (EUR)</th>
                                    <th>Phone </th>
                                    <th colSpan="4">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            {waiters.map(waiter => {
                                return <tr key={waiter.waiterId}>
                                        <td>
                                            {waiter.name}
                                        </td>
                                        <td>
                                            {waiter.surname}
                                        </td>
                                        <td>
                                            {waiter.age}
                                        </td>
                                        <td>
                                            {waiter.salary}
                                        </td>
                                        <td>
                                            {waiter.phone}
                                        </td>
                                    <td>
                                        <button type="button" className="btn btn-success" onClick={() => selectWaiter(waiter)} >Edit</button>
                                        </td>
                                        <td>
                                        <button type="button" onClick={() => deleteWaiter(waiter)} className="btn btn-danger">Delete</button>
                                        </td>
                                    </tr>  
                                })}
                            </tbody>
                        </table> 
                </div>}
            <div className="col" style={{ marginLeft: "4%" }}>
                <h4>Edit waiter</h4>
                <form>
                    <div className="form-group">
                        <label>First name</label>
                        <input type="text" className="form-control" placeholder="First name" onChange={e => setEditName(e.target.value)} value={editName} />
                    </div>
                    <div className="form-group">
                        <label>Last name</label>
                        <input type="text" className="form-control" placeholder="Last name" onChange={e => setEditSurname(e.target.value)} value={editSurname} />
                    </div>
                    <label>Age</label>
                    <input type="number" className="form-control" placeholder="Age" onChange={e => setEditAge(e.target.value)} value={editAge} />
                    <div className="form-group">
                        <label>Salary</label>
                        <select type="select" className="form-control" onChange={e => setEditSalary(e.target.value)} value={editSalary} >
                            <option>100</option>
                            <option>200</option>
                            <option>250</option>
                            <option>300</option>
                            <option>350</option>
                            <option>400</option>
                        </select>
                    </div>
                    <div className="form-group">
                        <label>Phone number</label>
                        <input type="text" className="form-control" placeholder="Phone number" onChange={e => setEditPhone(e.target.value)} value={editPhone} />
                    </div>
                    <Button onClick={() => editWaiter()} >Finish</Button>
                </form>
            </div>
        </div>
    );

       
  
}
