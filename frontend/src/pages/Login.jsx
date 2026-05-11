import "../styles/auth.css";

import { useState } from "react";

import {
  useNavigate,
  Link
} from "react-router-dom";

function Login() {

  const navigate = useNavigate();

  const [email,setEmail] = useState("");

  const [password,setPassword] = useState("");

  const handleSubmit = (e) => {

    e.preventDefault();

    const users =
    JSON.parse(localStorage.getItem("users")) || [];

    const matchedUser = users.find(
      (user)=>

        user.email === email &&
        user.password === password
    );

    if(matchedUser){

      localStorage.setItem(
        "user",
        JSON.stringify(matchedUser)
      );

      alert("Login Successful!");

      navigate("/");

      window.location.reload();

    }else{

      alert("Invalid Credentials!");

    }

  };

  return (

    <section className="auth-page">

      <div className="auth-container">

        <div className="auth-left">

          <h1>Welcome Back</h1>

          <p>
            Sign in to continue your journey
            with Mridangini and explore
            handcrafted traditions.
          </p>

        </div>

        <div className="auth-right">

          <form onSubmit={handleSubmit}>

            <input
              type="email"
              placeholder="Email Address"
              value={email}
              onChange={(e)=>
                setEmail(e.target.value)
              }
              required
            />

            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e)=>
                setPassword(e.target.value)
              }
              required
            />

            <button type="submit">
              Login
            </button>

            <div className="auth-switch">

              <p>

                Don't have an account?

                <Link to="/signup">
                  Sign Up
                </Link>

              </p>

            </div>

          </form>

        </div>

      </div>

    </section>

  );
}

export default Login;