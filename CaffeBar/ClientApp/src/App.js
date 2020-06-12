import React, { useState, useReducer, useEffect, useMemo } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Tables from './components/Tables';
import Waiters from './components/Waiters';
import Drinks from './components/Drinks';
import Decoration from './components/Decoration'
import Login from './components/Login'
import GuestPage from './components/GuestPage'
import {AuthContext} from './components/AuthContext';


import './custom.css'

export default function App() {
    const [state, dispatch] = useReducer(
        (prevState, action) => {
            switch (action.type) {
                case 'RESTORE_USER':
                    return {
                        ...prevState,
                        userToken: action.token,
                    };
                case 'SIGN_IN':
                    return {
                        ...prevState,
                        isOut: false,
                        userToken: action.token,
                    };
                case 'SIGN_OUT':
                    return {
                        ...prevState,
                        isOut: true,
                        userToken: null,
                    };
               }
            },
            {
                isOut: false,
                userToken: null
            }
    );

    useEffect(() => {
        const bootstrapAsync = async () => {
            let userToken;
            try {
                userToken = await localStorage.getItem('userToken');
            }
            catch (e) {
                console.log(JSON.stringify(e));
            }
            dispatch({ type: 'RESTORE_USER', token: userToken });
        };
        bootstrapAsync();
    }, [])

    const authValue = useMemo(
        () => ({
            signIn: async token => {
                dispatch({ type: 'SIGN_IN', token: token });
            },
            signOut: () => dispatch({ type: 'SIGN_OUT' }),
        }),[])

    return (
        <AuthContext.Provider value={authValue}>
            {state.userToken == null ? (
                <Layout>
                    <Route exact path='/' component={Login} />
                    <Route path='/waiters' component={Login} />
                    <Route path='/drinks' component={GuestPage} />
                    <Route path='/decoration' component={Login} />
                    <Route path='/login' component={Login} />
                </Layout>) : (
                    <Layout>
                        <Route exact path='/' component={Tables} />
                        <Route path='/waiters' component={Waiters} />
                        <Route path='/drinks' component={Drinks} />
                        <Route path='/decoration' component={Decoration} />
                        <Route path='/login' component={Login} />
                    </Layout>
                        )}
        </AuthContext.Provider>
    );
  
}
