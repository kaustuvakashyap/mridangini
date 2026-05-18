import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import "../styles/signup.css";

function Signup() {

    const navigate = useNavigate();
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [address, setAddress] = useState("");
    const [role, setRole] = useState("customer");

    function handleSignup(e) {
        e.preventDefault();
        const users = JSON.parse(localStorage.getItem("users")) || [];
        const userExists = users.find((user) => user.email === email);

        if (userExists) {
            alert("User already exists. Please login.");
            return;
        }

        const newUser = { name, email, password, address, role };

        users.push(newUser);
        localStorage.setItem(
            "users",
            JSON.stringify(users)
        );

        alert("Signup Successful!");

        localStorage.setItem("user", JSON.stringify(newUser));

        if (role === "seller") {
            navigate("/seller-dashboard");
        }else {
            navigate("/");
        }
    }

    return (

        <section className="signup-page">
            <div className="signup-box">
                <h1>Create Account</h1>

                <form onSubmit={handleSignup}>

                    <input
                        type="text"
                        placeholder="Full Name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                    />
                    <input
                        type="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                    <input
                        type="text"
                        placeholder="Address"
                        value={address}
                        onChange={(e) => setAddress(e.target.value)}
                        required
                    />

                    {/* ROLE SELECTOR */}

                    <div className="role-selector">
                        <button type="button"

                            className={
                                role === "customer" ? "active-role" : ""
                            }
                            onClick={() =>
                                setRole("customer")
                            }
                        > Customer</button>

                        <button type="button"

                            className={
                                role === "seller" ? "active-role" : ""
                            }
                            onClick={() =>
                                setRole("seller")
                            }
                        > Seller </button>
                    </div>

                    <button type="submit" className="signup-btn"> Signup </button>
                </form>

                <p> Already have an account? <Link to="/login"> Login </Link> </p>
            </div>
        </section>
    );
}

export default Signup;