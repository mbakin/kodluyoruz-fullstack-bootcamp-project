import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import 'bootstrap/dist/css/bootstrap.min.css'
import {MovieProvider} from './context/MovieContext'


ReactDOM.render(
  <React.StrictMode>
    <MovieProvider>
    <App  />
    </MovieProvider>
  </React.StrictMode>,
  document.getElementById('root')
);