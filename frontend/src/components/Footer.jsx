import "../styles/footer.css";

import footerLogo from "../assets/MridLogo.svg";
import borderImg from "../assets/gamusa_diamond_flower.png";

import { Link } from "react-router-dom";

function Footer() {

  return (

    <footer className="footer">
      <div className="footer-content">
        {/* LEFT */}

        <div className="footer-left">
          <img src={footerLogo} alt="" className="footer-logo"/>
          <h2>MRIDANGINI</h2>
          <p>MUSIC.CULTURE.CONNECTION.</p>
        </div>

        {/* CENTER */}

        <div className="footer-center">
          <h3>Quick Links</h3>
          <Link to="/">Home</Link>
          <a href="/#shop"> Shop </a>
          <Link to="/about"> About Us </Link>
          <Link to="/orders"> Orders </Link>
          <Link to="/contact"> Contact </Link>
        </div>

        {/* RIGHT */}
        <div className="footer-right">
          <h3>Newsletter</h3>
          <p>Subscribe to newsletter for updates and exclusive offers.</p>
          <div className="newsletter-box">
            <input type="email" placeholder="Enter your email"/>
          </div>
        </div>
      </div>

      {/* BOTTOM BORDER */}
      <div className="footer-border" style={{ backgroundImage: `url(${borderImg})`}}></div>

    </footer>
  );
}

export default Footer;