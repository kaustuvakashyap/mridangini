import "../styles/hero.css";
import heroImage from "../assets/hero.png";

function Hero() {
  return (
    <section className="hero">

      <div className="hero-left">

        <h1>
          Rooted in Tradition,
          <br />
          Made to Resonate.
        </h1>

        <p>
          Explore handcrafted musical instruments
          from Assam and the Northeast.
          A blend of rhythm, culture and heritage.
        </p>

        <button>Explore Collection</button>

      </div>

      <div className="hero-right">
        <img src={heroImage} alt="" />
      </div>

    </section>
  );
}

export default Hero;