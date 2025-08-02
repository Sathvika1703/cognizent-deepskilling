import React, { useState } from "react";
import CurrencyConvertor from "./CurrencyConvertor";

function App() {
  const [count, setCount] = useState(0);

  const increment = () => {
    setCount(count + 1);
    sayHello();
  };

  const decrement = () => {
    setCount(count - 1);
  };

  const sayHello = () => {
    alert("Hello! You just increased the counter.");
  };

  const sayWelcome = (msg) => {
    alert(msg);
  };

  const handleSyntheticClick = () => {
    alert("I was clicked");
  };

  return (
    <div style={{ padding: "30px", fontFamily: "Arial" }}>
      <h2 style={{ color: "green" }}>Currency Convertor!!!</h2>

      <div style={{ marginBottom: "20px" }}>
        <h3>Counter Value: {count}</h3>
        <button onClick={increment}>Increment</button>
        <button onClick={decrement} style={{ marginLeft: "10px" }}>
          Decrement
        </button>
      </div>

      <div style={{ marginBottom: "20px" }}>
        <button onClick={() => sayWelcome("Welcome")}>Say Welcome</button>
      </div>

      <div style={{ marginBottom: "20px" }}>
        <button onClick={handleSyntheticClick}>Click on me</button>
      </div>

      <CurrencyConvertor />
    </div>
  );
}

export default App;
