import "../styles/features.css";
import {
    LeafOne24Regular,
    Star24Regular,
    Heart24Regular,
    VehicleTruckProfile24Regular
} from "@fluentui/react-icons";

function Features() {
    return (

        <section className="features">

            <div className="feature-box">

                <div className="icon">
                    <LeafOne24Regular />
                </div>

                <div>
                    <h2>Handcrafted</h2>

                    <p>
                        Lovingly handcrafted by skilled artisans
                        of the Northeast.
                    </p>
                </div>

            </div>

            <div className="feature-box">

                <div className="icon">
                    <Star24Regular />
                </div>

                <div>
                    <h2>Authentic</h2>

                    <p>
                        100% authentic instruments rooted
                        in culture and tradition.
                    </p>
                </div>

            </div>

            <div className="feature-box">

                <div className="icon">
                    <Heart24Regular />
                </div>

                <div>
                    <h2>Support Local</h2>

                    <p>
                        Empowering local artisans and preserving
                        musical heritage.
                    </p>
                </div>

            </div>

            <div className="feature-box">

                <div className="icon">
                    <VehicleTruckProfile24Regular />
                </div>

                <div>
                    <h2>Worldwide Delivery</h2>

                    <p>
                        Delivering joy and rhythm
                        to your doorstep.
                    </p>
                </div>

            </div>

        </section>

    );
}

export default Features;