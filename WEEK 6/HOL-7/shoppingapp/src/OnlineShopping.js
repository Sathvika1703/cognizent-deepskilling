import React, { Component } from 'react';
import Cart from './Cart';

class OnlineShopping extends Component {
  render() {
    const items = [
      { itemname: 'Laptop', price: 50000 },
      { itemname: 'Smartphone', price: 20000 },
      { itemname: 'Headphones', price: 1500 },
      { itemname: 'Keyboard', price: 1000 },
      { itemname: 'Mouse', price: 800 },
    ];

    return (
      <div>
        <h2>Shopping Cart</h2>
        {items.map((item, index) => (
          <Cart key={index} itemname={item.itemname} price={item.price} />
        ))}
      </div>
    );
  }
}

export default OnlineShopping;
