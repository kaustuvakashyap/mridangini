import Navbar from "../components/Navbar";
import Footer from "../components/Footer";

import "../styles/cart.css";

function Cart() {

  const cartItems =
  JSON.parse(localStorage.getItem("cart")) || [];

  return (

    <>

      <Navbar />

      <section className="cart-page">

        <div className="cart-container">

          <h1>
            Your Cart
          </h1>

          {
            cartItems.length === 0 ? (

              <div className="empty-cart">

                <h2>
                  Your cart is empty
                </h2>

                <p>
                  Add handcrafted treasures
                  to see them here.
                </p>

              </div>

            ) : (

              <div className="cart-items">

                {
                  cartItems.map((item,index)=>(

                    <div
                      className="cart-card"
                      key={index}
                    >

                      <img
                        src={item.image}
                        alt={item.name}
                      />

                      <div className="cart-info">

                        <h3>
                          {item.name}
                        </h3>

                        <p>
                          ₹ {item.price}
                        </p>

                      </div>

                    </div>

                  ))
                }

              </div>

            )
          }

        </div>

      </section>

    </>

  );
}

export default Cart;