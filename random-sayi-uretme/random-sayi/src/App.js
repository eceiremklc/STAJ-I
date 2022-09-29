import "./style.css"
import React, {useState} from "react";
function App() {

  const[minVal, setMinVal] =useState(0);
  const[maxVal, setMaxVal] =useState(100);
  const[randomNum, setRandomNum] =useState(5);
  const giveRandomNumber=()=>{
    setRandomNum(Math.floor(Math.random()*(maxVal-minVal+1)+minVal))
  }
  return (
    <div className="hero">
      <div className="container">
        <div className="randomNum">
          <p>Random Sayı: <span>{randomNum}</span></p>
        </div>
        <div className="numContainer">
          <div>
            <p>Min:</p>
            <input 
            type="number" 
            value={minVal}
            onChange={e => setMinVal(e.target.value)}
            />
          </div>
          <div>
            <p>Max:</p>
            <input 
            type="number"
            value={maxVal}
            onChange={e => setMaxVal(e.target.value)}
            />
          </div>
        </div>
        <button onClick={giveRandomNumber}>Random Sayı Getir</button>
      </div>
    </div>
  );
}

export default App;
