import "../styles/orders.css";

function Orders() {

  // EMPTY initially

  const orders = [];

  return (

    <section className="orders-page">

      <div className="orders-header">

        <h1>Your Orders</h1>

        <p>
          Track your handcrafted treasures
          and cultural collections.
        </p>

      </div>

      {
        orders.length === 0 ? (

          <div className="empty-orders">

            <h2>No Orders Yet</h2>

            <p>
              Your ordered instruments and
              handcrafted collections will
              appear here once you make a purchase.
            </p>

          </div>

        ) : (

          <div className="orders-container">

            {
              orders.map((item,index)=>(

                <div className="order-card" key={index}>

                  <h2>{item.product}</h2>

                </div>

              ))
            }

          </div>

        )
      }

    </section>

  );
}

export default Orders;