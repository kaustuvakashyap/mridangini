import "../styles/about.css";

import aboutImage from "../assets/MridLogo.svg";

function About() {

  return (

    <section className="about-page">

      <div className="about-container">

        <div className="about-left">

          <img src={aboutImage} alt="" />

        </div>

        <div className="about-right">

          <h1>About Mridangini</h1>

          <p>
            Mridangini is more than a marketplace —
            it is a celebration of rhythm, heritage,
            and the artistic soul of Northeast India.
          </p>

          <p>
            Rooted in tradition and inspired by the
            cultural richness of Assam, our platform
            brings handcrafted musical instruments,
            folk artistry, and authentic craftsmanship
            closer to people across the world.
          </p>

          <p>
            Every instrument carries the voice of an artisan,
            the memory of generations, and the heartbeat
            of tradition. Through Mridangini, we aim to
            preserve these timeless crafts while empowering
            local creators and communities.
          </p>

        </div>

      </div>

    </section>

  );
}

export default About;