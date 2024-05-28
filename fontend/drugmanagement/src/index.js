import React from 'react';
import ReactDOM from 'react-dom/client';
import Homepage from './Pages/User/homepage/index';
import {BrowserRouter } from 'react-router-dom';
import RouterCustom from './router';
import './Styles/style.scss';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <BrowserRouter>
        <RouterCustom/>
    </BrowserRouter>
);
