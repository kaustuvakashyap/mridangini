import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import Footer from "../components/Footer";
import "../styles/orders.css";

function Orders(){

    const [orders, setOrders] = useState([]);

    useEffect(()=>{
        const currentUser = JSON.parse(localStorage.getItem("user"));

        if(!currentUser){
            setOrders([]);
            return;
        }

        const storedOrders = JSON.parse(localStorage.getItem("orders")) || [];

        const userOrders = storedOrders.filter((order)=>
            order.customer === currentUser.name
        );

        setOrders(userOrders);

    },[]);

    return(
        <>
            <Navbar />
            <section className="orders-page">
                <h1>Your Orders</h1>

                {
                    orders.length === 0 ?

                    <div className="empty-orders">
                        <h2>No Orders Yet</h2>
                    </div>
                    :
                    <div className="orders-container">
                        {
                            orders.map((order)=>(
                                <div className="order-card" key={order.id}>
                                    <div className="order-top">
                                        <div>
                                            <h2> Order ID: {" "} {order.id} </h2>
                                            <p> {order.date}</p>
                                        </div>
                                        <span className="order-status"> {order.status}</span>
                                    </div>

                                    <div className="ordered-items">
                                        {
                                            order.items.map((item)=>(
                                                <div className="ordered-item" key={item.id} >
                                                    <img src={item.image} alt=""/>
                                                    <div>
                                                        <h3> {item.title || item.name}</h3>
                                                        <p> ₹ {item.price}</p>
                                                        <p> Qty: {" "} {item.quantity}</p>
                                                    </div>
                                                </div>
                                            ))
                                        }
                                    </div>

                                    <h2 className="order-total"> Total: {" "} ₹ {order.total} </h2>
                                </div>
                            ))
                        }

                    </div>
                }
            </section>
        </>
    );
}

export default Orders;