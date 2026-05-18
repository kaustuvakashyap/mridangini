import {
    Link,
    useNavigate
} from "react-router-dom";
import "../styles/navbar.css";
import logo from "../assets/MridLogo.svg";
import {
    Search24Regular,
    Person24Regular,
    Cart24Regular
} from "@fluentui/react-icons";

function Navbar() {
    const user = JSON.parse(localStorage.getItem("user"));
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem("user");
        navigate("/");
        window.location.reload();
    };

    return (
        <nav className="navbar">
            <div className="logo">
                <img src={logo} alt="logo" />
                <div className="logo-text">
                    <h1>mridangini</h1>
                    <p>sound of your soil and soul</p>
                </div>
            </div>

            <ul className="nav-links">
                <li onClick={() => window.scrollTo({ top: 0, behavior: "smooth" })}>
                    <Link to="/">Home</Link>
                </li>
                <li><a href="/#shop">Shop</a></li>
                <li><Link to="/about">About</Link></li>
                <li><Link to="/orders">Orders</Link></li>
                <li><Link to="/contact">Contact</Link></li>
            </ul>
            <div className="nav-icons">
                <Search24Regular />{ user ? (
                        <div className="profile-wrapper">
                            <div className="profile-icon">
                                <span>{user.name.charAt(0).toUpperCase()}</span>
                            </div>
                            <div className="logout-dropdown">
                                <button onClick={handleLogout}>Logout</button>
                            </div>
                        </div>
                    ) : (
                        <Link to="/login"> <Person24Regular /> </Link>
                    )
                }
                <Link to="/cart"><Cart24Regular /></Link>
            </div>
        </nav>
    );
}


export default Navbar;