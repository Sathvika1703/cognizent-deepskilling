import React, { useState } from "react";

const CurrencyConvertor = () => {
  const [amount, setAmount] = useState("");
  const [currency, setCurrency] = useState("Euro");

  const handleSubmit = (e) => {
    e.preventDefault();

    const amt = parseFloat(amount);
    if (isNaN(amt) || amt <= 0) {
      alert("Please enter a valid amount.");
      return;
    }

    let result = 0;
    let message = "";

    if (currency === "Euro") {
      result = amt * 80; 
      message = `Converting to ${currency}. Amount is ₹${result}`;
    } else if (currency === "Rupees") {
      result = amt / 80; 
      message = `Converting to ${currency}. Amount is €${result.toFixed(2)}`;
    }

    alert(message);
  };

  return (
    <div style={{ marginTop: "40px" }}>
      <h2 style={{ color: "green" }}>Currency Convertor!!!</h2>

      <form onSubmit={handleSubmit}>
        <div>
          <label>
            <strong>Amount: </strong>
          </label>
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(e.target.value)}
            placeholder="Enter amount"
            required
          />
        </div>
        <br />
        <div>
          <label>
            <strong>Currency: </strong>
          </label>
          <select
            value={currency}
            onChange={(e) => setCurrency(e.target.value)}
          >
            <option value="Euro">Euro</option>
            <option value="Rupees">Rupees</option>
          </select>
        </div>
        <br />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default CurrencyConvertor;
