
import React from "react";
import officeList from "./officeData";

const App = () => {
  return (
    <div style={{ padding: "20px", textAlign: "center" }}>
      <h1 style={{ color: "black" }}>Office Space , at Affordable Range</h1>

      {officeList.map((office, index) => (
        <div key={index} style={{ marginBottom: "30px" }}>
          <img
            src={office.image}
            alt={office.name}
            width="300"
            height="200"
            style={{ borderRadius: "8px" }}
          />
          <h2>Name: {office.name}</h2>
          <p
            style={{
              color: office.rent < 60000 ? "red" : "green",
              fontWeight: "bold"
            }}
          >
            Rent: Rs. {office.rent}
          </p>
          <p>Address: {office.address}</p>
        </div>
      ))}
    </div>
  );
};

export default App;
