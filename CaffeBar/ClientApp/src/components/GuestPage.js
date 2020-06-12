import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button } from 'reactstrap'

export default function GuestPage() {

    const [drinks, setDrinks] = useState([]);
    const [loading, setLoading] = useState(true);

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
    return (
        <div className="row">
            <div className="col" style={{ marginRight: "4%" }}>
            </div>
            {loading ? <h1>Loading</h1> :
                <div className="row" style={{ maxWidth:'95%' }}>
                    <h4 align="center">Drink List</h4>
                    <table className="table table-striped" style={{ marginTop: 10 }}>
                        <thead>
                            <tr>
                                <th>Title</th>
                                <th>Price (EUR)</th>
                                <th>Tax rate</th>
                                <th>Available</th>
                            </tr>
                        </thead>
                        <tbody>
                            {drinks.map(drink => {
                                return <tr key={drink.drinkId}>
                                    <td>
                                        <strong>{drink.title}</strong>
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
                                </tr>
                            })}
                        </tbody>
                    </table>
                </div>}
            <div className="col" style={{ marginLeft: "4%" }}>
            </div>
        </div>
    );



}
