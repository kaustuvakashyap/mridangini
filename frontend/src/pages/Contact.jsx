import "../styles/contact.css";

function Contact() {

  return (

    <section className="contact-page">

      <div className="contact-container">

        <div className="contact-left">

          <h1>Get in Touch</h1>

          <p>
            We would love to hear from you.
            Whether you wish to explore our
            handcrafted collections, collaborate
            with artisans, or simply connect with us,
            Mridangini welcomes your message.
          </p>

          <div className="contact-info">

            <div className="info-box">

              <h3>Email</h3>

              <p>hello@mridangini.com</p>

            </div>

            <div className="info-box">

              <h3>Phone</h3>

              <p>+91 98765 43210</p>

            </div>

            <div className="info-box">

              <h3>Location</h3>

              <p>Guwahati, Assam, India</p>

            </div>

          </div>

        </div>

        <div className="contact-right">

          <form>

            <input
              type="text"
              placeholder="Your Name"
            />

            <input
              type="email"
              placeholder="Your Email"
            />

            <textarea
              placeholder="Your Message"
            ></textarea>

            <button type="submit">
              Send Message
            </button>

          </form>

        </div>

      </div>

    </section>

  );
}

export default Contact;