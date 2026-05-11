import "../styles/auth.css";

import { useState } from "react";

import {
  useNavigate,
  Link
} from "react-router-dom";

function Signup() {

  const navigate = useNavigate();

  const [formData,setFormData] = useState({

    name:"",
    email:"",
    phone:"",
    address:"",
    password:""

  });

  const handleChange = (e) => {

    setFormData({

      ...formData,

      [e.target.name]:e.target.value

    });

  };

 const handleSubmit = (e) => {

  e.preventDefault();

  const users =
  JSON.parse(localStorage.getItem("users")) || [];

  const userExists = users.find(
    (user) => user.email === formData.email
  );

  if(userExists){

    alert(
      "User already exists. Please Login."
    );

    navigate("/login");

    return;
  }

  users.push(formData);

  localStorage.setItem(
    "users",
    JSON.stringify(users)
  );

  localStorage.setItem(
    "user",
    JSON.stringify(formData)
  );

  alert("Account Created Successfully!");

  navigate("/");

  window.location.reload();

};

  return (

    <section className="auth-page">

      <div className="auth-container">

        <div className="auth-left">

          <h1>Create Account</h1>

        </div>

        <div className="auth-right">

          <form onSubmit={handleSubmit}>

            <input
              type="text"
              placeholder="Full Name"
              name="name"
              onChange={handleChange}
            />

            <input
              type="email"
              placeholder="Email Address"
              name="email"
              onChange={handleChange}
            />

            <input
              type="text"
              placeholder="Phone Number"
              name="phone"
              onChange={handleChange}
            />

            <input
              type="text"
              placeholder="Address"
              name="address"
              onChange={handleChange}
            />

            <input
              type="password"
              placeholder="Password"
              name="password"
              onChange={handleChange}
            />

            <button type="submit">
              Create Account
            </button>

            <div className="auth-switch">

              <p>
                Already have an account?

                <Link to="/login">
                  Login
                </Link>

              </p>

            </div>

          </form>

        </div>

      </div>

    </section>

  );
}

export default Signup;