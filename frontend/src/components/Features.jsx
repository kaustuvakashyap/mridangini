import "../styles/features.css";

import heartImg from "../assets/pic.jpg";
import assamImg from "../assets/pic2.jpg";
import busImg from "../assets/pic3.jpg";

function Features() {

  return (

    <section className="features-wrapper">
      <div className="features">
        <div className="feature-box">
          <img src={heartImg} alt="" />
          <div>
            <h3>Authentic & Handcrafted</h3>
            <p>
              Lovingly handcrafted and
              100% authentic instruments.
            </p>
          </div>
        </div>
        <div className="divider"></div>
        <div className="feature-box">
          <img src={assamImg} alt="" />
          <div>

            <h3>Local Products</h3>
            <p>
              Empowering local artisans and
              preserving our musical heritage.
            </p>
          </div>
        </div>
        <div className="divider"></div>
        <div className="feature-box">
          <img src={busImg} alt="" />
          <div>
            <h3>Worldwide Delivery</h3>
            <p>
              Delivering joy and rhythm
              to your doorstep anywhere.
            </p>
          </div>
        </div>
      </div>
    </section>
  );
}

export default Features;