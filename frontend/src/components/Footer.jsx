import "../styles/footer.css";

function Footer() {
  return (

    <footer className="footer">

      <div className="footer-left">

        <h1>Mridangini</h1>

        <p>
          Music. Culture. Connection.
        </p>

        <div className="socials">

          <span>📷</span>
          <span>📘</span>
          <span>▶️</span>
          <span>📌</span>

        </div>

      </div>

      <div className="footer-center">

        <h2>Quick Links</h2>

        <ul>
          <li>Shop</li>
          <li>About Us</li>
          <li>Shipping & Returns</li>
          <li>Terms & Conditions</li>
          <li>Privacy Policy</li>
          <li>Contact Us</li>
        </ul>

      </div>

      <div className="footer-right">

        <h2>Newsletter</h2>

        <p>
          Subscribe to our newsletter
          for updates and offers.
        </p>

        <div className="newsletter">

          <input
            type="email"
            placeholder="Your email"
          />

          <button>→</button>

        </div>

      </div>

    </footer>

  );
}

export default Footer;