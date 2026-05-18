import { useEffect, useState } from "react";
import "../styles/hero.css";

import hero1 from "../assets/InstrumentsHeaders/tweak.png";
import hero2 from "../assets/InstrumentsHeaders/borTal.png";
import hero3 from "../assets/InstrumentsHeaders/Dhol2.png";
import hero4 from "../assets/InstrumentsHeaders/pepa.png";

function Hero() {
    const images = [hero1, hero2, hero3, hero4];
    const [currentImage, setCurrentImage] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
            setCurrentImage((prev) =>
                prev === images.length - 1 ? 0 : prev + 1
            );
        }, 3500);

        return () => clearInterval(interval);
    }, [images.length]);

    return (
        <section className="hero">
            <div className="hero-left">
                <h1> Rooted in Tradition, <br /> Made to Resonate.</h1>
                <p> Explore handcrafted musical instruments from Assam and the Northeast. A blend of rhythm, culture and heritage</p>
                <button>Explore Collection</button>
            </div>

            <div className="hero-right">
                <img key={currentImage} src={images[currentImage]} alt="" className="hero-slide" />
            </div>
        </section>
    );
}

export default Hero;