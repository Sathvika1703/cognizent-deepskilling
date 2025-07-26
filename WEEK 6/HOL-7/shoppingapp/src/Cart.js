import React, { Component } from 'react';

class Cart extends Component {
  render() {
    const { itemname, price } = this.props;
    return (
      <p>
        <strong>Item:</strong> {itemname} | <strong>Price:</strong> ₹{price}
      </p>
    );
  }
}

export default Cart;
