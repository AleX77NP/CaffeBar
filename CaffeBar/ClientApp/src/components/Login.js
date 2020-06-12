import React, { useState, useEffect, useContext } from 'react';
import axios from 'axios';
import { AuthContext } from './AuthContext';

export default function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [hide, setHide] = useState(true);
    const { signIn } = useContext(AuthContext);

    const changeHide = () => {
        setHide(!hide);
    }

    const login = async () => {
        let data = {
            "Username": username,
            "Password": password
        }
        axios.request({
            method: 'POST',
            url: "http://localhost:59963/api/auth/login",
            data
        }).then(async(response) => {
            try {
                await localStorage.setItem('userToken', response.data.username);
                await signIn(response.data.password);
            }
            catch (e) {
                console.log(e);
            }
            console.log(response);
        }).catch((error) => { alert("Check Your inputs please."); console.log(error); })
    }

    return (
        <div className="row" style={{ marginTop: '10%', marginBottom: '12%'}}>
            <div className="col">
            </div>
            <div className="col">
                <form style={{ border: '1px solid black', padding: '35px', borderRadius: '5%' }}>
                    <div className="form-group">
                        <label>Username</label>
                        <input type="text" className="form-control" onChange={e => setUsername(e.target.value)} id="exampleUser" aria-describedby="userHelp" placeholder="Enter username" required />
                            <small id="user" className="form-text text-muted">Enter your caffe username here.</small>
                         </div>
                        <div className="form-group">
                        <label>Password</label>
                        <input type={hide ? 'password' : 'text'} className="form-control" onChange={e => setPassword(e.target.value)} id="exampleInputPassword1" placeholder="Password" required />
                             </div>
                    <div className="form-check">
                        <input type="checkbox" className="form-check-input" id="exampleCheck1" onClick={() => changeHide()} />
                                    <label className="form-check-label">Show password</label>
                    </div>
                    <button type="button" className="btn btn-primary" style={{ marginTop: '2.5%' }} onClick={()=>login()}>Sign In</button>
                               </form>
                          </div>
            <div className="col">
            </div>
        </div>
   );
}