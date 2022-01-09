import React,{useEffect,useState} from 'react';
import axios from 'axios';
import logo from './logo.svg';
import './App.css';

function App() {
  const[activity,setActivity]=useState([]);
  useEffect(() => {
    axios.get('http://localhost:5000/api/Activity')
    .then(response =>{
      setActivity(response.data)
    } );
  },[]);
 
  return (
    <div className="App">
      <h3>Arnab</h3>
      <ul>
      {activity.map((act:any)=>(
        <li key={act.id}>{act.title}</li>
      ))}
      </ul>
    </div>
  );
}

export default App;
