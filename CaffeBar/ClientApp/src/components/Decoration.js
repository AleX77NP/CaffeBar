import React, { useState, useEffect, useContext } from 'react';
import axios from 'axios';
import { Button } from 'reactstrap'
import { AuthContext } from './AuthContext';

export default function Decoration() {
    const [tables, setTables] = useState([]);
    const [loading, setLoading] = useState(true);
    const [newMarking, setNewMarking] = useState('');
    const [newTitle, setNewTitle] = useState('');
    const [editMarking, setEditMarking] = useState('');
    const [editTitle, setEditTitle] = useState('');
    const [selectedTable, setSelectedTable] = useState({ tableId: 0, marking: "00", title: "Table 00", taken: false });
    const { signOut } = useContext(AuthContext);

    useEffect(() => {
        getTables();
    }, [])

    const getTables = () => {
        axios.get("http://localhost:59963/api/tables").then((response) => {
            setTables(response.data)
            console.log(JSON.stringify(response.data));
            setLoading(false);
        }).catch((error) => { console.log(error) })
    }

    const addTable = () => {
        let data = {
            "Marking": newMarking,
            "Title": newTitle
        }
        if (newMarking.length !== 2 || !newTitle.includes("Table")) {
            alert("Inputs are invalid.");
            return;
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/tables/create",
            data
        }).then((response) => {
            getTables();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }

    const editTable = () => {
        let data = {
            "Marking": editMarking,
            "Title": editTitle
        }
        if (editMarking.length !== 2 || !editTitle.includes("Table")) {
            alert("Inputs are invalid.");
            return;
        }
        axios.request({
            method: 'PUT',
            url: "http://localhost:59963/api/tables/edit/" + selectedTable.tableId,
            data
        }).then((response) => {
            getTables();
            alert(response.data);
        }).catch((error) => { alert("Check inputs please."); console.log(error); })
    }

    const deleteTable = (table) => {
        let id = table.tableId;
        setTables(tables.filter(table => table.tableId !== id));
        axios.delete("http://localhost:59963/api/tables/delete/" + table.tableId).then((response) => {
            alert(JSON.stringify(response.data));
        }).catch((error) => { console.log(error) })
    }

    const selectTable = (table) => {
        setSelectedTable(table);
        setEditMarking(table.marking);
        setEditTitle(table.title);
    }

    const logout = async() => {
        try {
            await localStorage.removeItem('userToken');
            signOut();
        } catch (e) {
            console.log(e);
        }
    }
  
    return (
        <div className="row">
            <div className="col">
                <h4>Add new</h4>
                <form>
                    <div className="form-group">
                        <label>Marking</label>
                        <input type="text" className="form-control" placeholder="Marking" onChange={e => setNewMarking(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label>Title</label>
                        <input type="text" className="form-control" placeholder="Title" onChange={e => setNewTitle(e.target.value)} />
                    </div>
                    <Button onClick={() => addTable()}>Submit</Button>
                </form>
            </div>
            {loading ? <h1>Loading</h1> :
                <div className="col-md-8">
                    <div className="row">
                        {tables.map(table => {
                            return <div className="col-md-4" key={table.tableId}>
                                <div className="card mb-4 shadow-sm">
                                    <img className="bd-placeholder-img card-img-top" width="100%"
                                        src={require('../images/freeTable.png')} alt="table" />
                                    <div className="card-body">
                                        <p className="card-text font-weight-bold" style={{ textAlign: 'center' }}>{table.title}</p>
                                        <div className="d-flex justify-content-between align-items-center">
                                            <div className="btn-group" style={{ marginLeft: '11%' }}>
                                                <button type="button"
                                                    className="btn btn-sm btn-success product-btn" onClick={() => selectTable(table)} >Edit table</button>
                                                <button type="button" onClick={() => deleteTable(table)}  className="btn btn-sm btn-danger product-btn">Delete</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        })}
                    </div></div>}

            <div className="col">
                <h4>Edit table</h4>
                <form>
                    <div className="form-group">
                        <label>Marking</label>
                        <input type="text" className="form-control" placeholder="Marking" onChange={e => setEditMarking(e.target.value)} value={editMarking} />
                    </div>
                    <div className="form-group">
                        <label>Title</label>
                        <input type="text" className="form-control" placeholder="Title" onChange={e => setEditTitle(e.target.value)} value={editTitle} />
                    </div>
                    <Button onClick={() => editTable()} >Finish</Button>
                </form>
                <br />
                <hr />
                <button type="button" className="btn btn-primary" style={{ marginTop: '2.5%' }} onClick={() => logout()}>Sign Out</button>
            </div>
        </div>
    );
}
