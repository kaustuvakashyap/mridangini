import { BrowserRouter, Routes, Route } from "react-router-dom";
import ScrollToTop from "./components/ScrollToTop";

import Navbar from "./components/Navbar";
import Footer from "./components/Footer";

import Home from "./pages/Home";
import About from "./pages/About";
import Orders from "./pages/Orders";
import Contact from "./pages/Contact";
import Login from "./pages/Login";
import Signup from "./pages/Signup";
import Cart from "./pages/Cart";
import CategoryPage from "./pages/CategoryPage";
import SellerDashboard from "./pages/SellerDashboard";

function App() {

  return (

    <BrowserRouter>
      <ScrollToTop />

      <div className="top-border"></div>

      <Navbar />

      <Routes>

        <Route path="/" element={<Home />} />

        <Route path="/about" element={<About />} />

        <Route path="/orders" element={<Orders />} />

        <Route path="/contact" element={<Contact />} />

        <Route path="/category/:type" element={<CategoryPage />} />

        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />

        <Route path="/cart" element={<Cart />} />
        <Route path="/seller-dashboard" element={<SellerDashboard />}/>
      </Routes>

      <Footer />

    </BrowserRouter>

  );
}

export default App;