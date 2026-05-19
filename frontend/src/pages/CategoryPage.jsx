import Navbar from "../components/Navbar";
import Footer from "../components/Footer";
import "../styles/categoryPage.css";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import api from "../api/api";

import percussion1 from "../assets/Inst_AIed/Bihu_Dhul.jpg";
import percussion2 from "../assets/Inst_AIed/Mridanga.jpg";
import percussion3 from "../assets/Inst_AIed/Moran_Dhul.jpg";
import percussion4 from "../assets/Inst_AIed/Cheng_Burup.jpg";
import percussion5 from "../assets/Inst_AIed/Dhutong.jpg";

import wind1 from "../assets/Inst_AIed/Pepa.jpg";
import wind2 from "../assets/Inst_AIed/Gogona.jpg";
import wind3 from "../assets/Inst_AIed/Mori_Pongsi.jpg";
import wind4 from "../assets/Inst_AIed/Bojal_Bahor_Hutuli.jpg";
import wind5 from "../assets/Inst_AIed/Mori_Tongpo.jpg";
import wind6 from "../assets/Inst_AIed/Baghdhenu.jpg";

import string1 from "../assets/Inst_AIed/Veen.jpg";
import string2 from "../assets/Inst_AIed/Ektara.jpg";
import string3 from "../assets/Inst_AIed/Kichokbenu.jpg";
import string4 from "../assets/Inst_AIed/Jurtang.jpg";
import string5 from "../assets/Inst_AIed/Krong_Chui.jpg";
import string6 from "../assets/Inst_AIed/Kum_Dengdong.jpg";
import string7 from "../assets/Inst_AIed/Mori_Jang_kek.jpg";

import folk1 from "../assets/Inst_AIed/Taal.jpg";
import folk2 from "../assets/Inst_AIed/Kortal.jpg";
import folk3 from "../assets/Inst_AIed/Hutuli.jpg";
import folk4 from "../assets/Inst_AIed/Daskathiya.jpg";
import folk5 from "../assets/Inst_AIed/Kodital.jpg";
import folk6 from "../assets/Inst_AIed/Saksoni_and_Dangmari.jpg";

function CategoryPage() {
  const [backendProducts, setBackendProducts] = useState([]);
  const { type } = useParams();

  useEffect(() => { loadProducts(); }, []);

  const loadProducts = async () => {
    try {
      const response = await api.get("/products");
      console.log(response.data);
      setBackendProducts(response.data);
    } catch (error) {
      console.log(error);
    }
  };
  const products = {

    percussion: [
      {
        id: 1, title: "Bihu Dhul", price: 700,
        description: "Traditional Assamese festival drum handcrafted by local artisans.",
        image: percussion1
      },

      {
        id: 2, title: "Mridanga", price: 1200,
        description: "A traditional handcrafted drum from Assam.",
        image: percussion2
      },
      {
        id: 3, title: "Moran Dhul", price: 1500,
        description: "A traditional handcrafted drum from Assam.",
        image: percussion3
      },
      {
        id: 4, title: "Cheng Burup", price: 1800,
        description: "A traditional handcrafted drum from Assam.",
        image: percussion4
      },
      {
        id: 5, title: "Dhutong", price: 2600,
        description: "A traditional handcrafted drum from Assam.",
        image: percussion5
      }
    ],

    wind: [
      {
        id: 1, title: "Pepa", price: 1200,
        description: "A traditional wind instrument from Assam.",
        image: wind1
      },

      {
        id: 2, title: "Gogona", price: 1800,
        description: "A traditional wind instrument from Assam.",
        image: wind2
      },
      {
        id: 3, title: "Mori Pongsi", price: 1300,
        description: "A traditional wind instrument from Assam.",
        image: wind3
      },
      {
        id: 4, title: "Bahor Hutuli", price: 900,
        description: "A traditional wind instrument from Assam.",
        image: wind4
      },
      {
        id: 5, title: "Mori Tongpo", price: 1600,
        description: "A traditional wind instrument from Assam.",
        image: wind5
      },
      {
        id: 6, title: "Baghdhenu", price: 2700,
        description: "A traditional wind instrument from Assam.",
        image: wind6
      }
    ],

    string: [
      {
        id: 1, title: "Veen", price: 4200,
        description: "A traditional string instrument from Assam.",
        image: string1
      },

      {
        id: 2, title: "Ektara", price: 5500,
        description: "A traditional string instrument from Assam.",
        image: string2
      },
      {
        id: 3, title: "Kichokbenu", price: 3500,
        description: "A traditional string instrument from Assam.",
        image: string3
      },
      {
        id: 4, title: "Jurtang", price: 2200,
        description: "A traditional string instrument from Assam.",
        image: string4
      },
      {
        id: 5, title: "Krong Chui", price: 1200,
        description: "A traditional string instrument from Assam.",
        image: string5
      },
      {
        id: 6, title: "Kum Dengdong", price: 900,
        description: "A traditional string instrument from Assam.",
        image: string6
      },
      {
        id: 7, title: "Mori Jangkek", price: 1500,
        description: "A traditional string instrument from Assam.",
        image: string7
      }
    ],

    folk: [
      {
        id: 1, title: "Taal", price: 2100,
        description: "A traditional folk instrument from Assam.",
        image: folk1
      },

      {
        id: 2, title: "Kortal", price: 700,
        description: "A traditional folk instrument from Assam.",
        image: folk2
      },
      {
        id: 3, title: "Hutuli", price: 700,
        description: "A traditional folk instrument from Assam.",
        image: folk3
      },
      {
        id: 4, title: "Daskathiya", price: 700,
        description: "A traditional folk instrument from Assam.",
        image: folk4
      },
      {
        id: 5, title: "Kodital", price: 700,
        description: "A traditional folk instrument from Assam.",
        image: folk5
      },
      {
        id: 6, title: "Saksoni", price: 700,
        description: "A traditional folk instrument from Assam.",
        image: folk6
      }
    ]
  };

  const staticProducts = products[type] || [];
  const dynamicProducts = JSON.parse(localStorage.getItem("products")) || [];
  const sellerProducts = dynamicProducts.filter((product) => product.category === type);

  // const apiProducts = backendProducts.filter((product) => product.category?.toLowerCase() === type.toLowerCase());
  // const selectedProducts = [...apiProducts];
  const selectedProducts = backendProducts.filter((product) => {

  const description = product.description?.toLowerCase() || "";

  if (type === "percussion") {
    return description.includes("percussion");
  }

  if (type === "wind") {
    return description.includes("wind");
  }

  if (type === "string") {
    return description.includes("string");
  }

  if (type === "folk") {
    return description.includes("folk");
  }

  return true;
});

  const addToCart = (product) => {
    const currentUser = JSON.parse(localStorage.getItem("user"));

    if (!currentUser) {
      alert("Please login first to add items to cart.");
      return;
    }

    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    const existingProduct = cart.find((item) => item.id === product.id);

    if (existingProduct) {
      alert("Item already added to cart.");
      return;
    }

    cart.push({ ...product, quantity: 1 });
    localStorage.setItem("cart", JSON.stringify(cart));
    alert("Item Added To Cart!");
  };

  const handleShopNow = (product) => {

    const currentUser = JSON.parse(localStorage.getItem("user"));

    if (!currentUser) {
      alert("Please login first to continue.");
      return;
    }

    const existingOrders = JSON.parse(localStorage.getItem("orders")) || [];

    const newOrder = {
      id: Date.now(),
      customer: currentUser.name,
      items: [{ ...product, quantity: 1 }],
      total: product.price,
      status: "Pending",
      date: new Date().toLocaleDateString()
    };

    existingOrders.push(newOrder);
    localStorage.setItem("orders", JSON.stringify(existingOrders));
    alert("Order Placed Successfully!");
  };

  return (
    <>
      <Navbar />
      <section className="category-page">
        <div className="category-container">
          <h1> {type.charAt(0).toUpperCase() + type.slice(1)} Collection</h1>

          <div className="product-grid">
            {
              selectedProducts.map((product) => (

                <div className="product-card" key={product.id}>

                  <img src={product.image || percussion1} alt={product.name || product.title} />
                  <h3> {product.name || product.title}</h3>

                  {
                    product.description && <span className="product-description"> {product.description}</span>
                  }

                  <p>₹ {product.price}</p>

                  <div className="product-buttons">
                    <button className="shop-btn" onClick={() => handleShopNow(product)}>Shop Now</button>
                    <button className="cart-btn" onClick={() => addToCart(product)}> Add To Cart</button>
                  </div>
                </div>
              ))
            }
          </div>
        </div>
      </section>
    </>
  );
}

export default CategoryPage;