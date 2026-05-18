import Navbar from "../components/Navbar";
import Footer from "../components/Footer";
import { useEffect, useState } from "react";

import "../styles/cart.css";


function Cart() {
  const [cartItems, setCartItems] = useState([]);

  useEffect(() => {
    const storedCart = JSON.parse(localStorage.getItem("cart")) || [];
    setCartItems(storedCart);
  }, []);

  function increaseQuantity(id) {
    const updatedCart = cartItems.map((item) => item.id === id ? {
      ...item,
      quantity: item.quantity + 1
    } : item
    );

    setCartItems(updatedCart);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
  }

  function decreaseQuantity(id) {
    const updatedCart = cartItems.map((item) => item.id === id ? {
      ...item,
      quantity: item.quantity > 1 ? item.quantity - 1 : 1
    } : item
    );

    setCartItems(updatedCart);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
  }

  function removeItem(id) {
    const updatedCart = cartItems.filter((item) => item.id !== id);

    setCartItems(updatedCart);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
  }

  const totalPrice = cartItems.reduce((total, item) => total + item.price * item.quantity, 0);

  function handleBuyNow() {
    const currentUser = JSON.parse(localStorage.getItem("user"));

    if (!currentUser) {
      alert("Please login first.");
      return;
    }

    if (cartItems.length === 0) {
      alert("Cart is empty.");
      return;
    }

    const existingOrders = JSON.parse(localStorage.getItem("orders")) || [];

    const newOrder = {
      id: Date.now(),
      customer: currentUser.name,
      items: cartItems,
      total: totalPrice,
      status: "Pending",
      date: new Date().toLocaleDateString()
    };

    existingOrders.push(newOrder);
    localStorage.setItem("orders", JSON.stringify(existingOrders));
    localStorage.removeItem("cart");
    setCartItems([]);
    alert("Order Placed Successfully!");
  }

  return (
    <>
      <Navbar />
      <section className="cart-page">
        <h1>Your Cart</h1>
        {
          cartItems.length === 0 ?
            <div className="empty-cart">
              <h2> Your cart is empty</h2>
            </div>
            :
            <div className="cart-container">
              <div className="cart-items">
                {
                  cartItems.map((item) => (
                    <div className="cart-card" key={item.id}>
                      <img src={item.image} alt={item.title} />

                      <div className="cart-info">
                        <h2 className="cart-product-title"> {item.title} </h2>
                        <h3 className="cart-product-price"> ₹ {item.price} </h3>
                        <div className="quantity-box">
                          <button onClick={() => decreaseQuantity(item.id)}>-</button>
                          <span>{item.quantity}</span>
                          <button onClick={() => increaseQuantity(item.id)}> +</button>
                        </div>
                        <button className="remove-btn" onClick={() => removeItem(item.id)}> Remove </button>
                      </div>

                    </div>
                  ))
                }

              </div>

              <div className="cart-summary">
                <h2>Order Summary</h2>
                <h3>Total: {" "} ₹ {totalPrice} </h3>
                <button onClick={handleBuyNow}>Buy Now</button>
              </div>
            </div>
        }
      </section>
    </>
  );
}

export default Cart;