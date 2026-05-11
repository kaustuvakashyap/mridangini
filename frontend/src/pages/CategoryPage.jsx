import Navbar from "../components/Navbar";
import Footer from "../components/Footer";

import "../styles/categoryPage.css";

import { useParams } from "react-router-dom";

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

  const { type } = useParams();

  const products = {

    percussion:[

      {
        id:1,
        name:"Bihu Dhul",
        price:700,
        image:percussion1
      },

      {
        id:2,
        name:"Mridanga",
        price:1200,
        image:percussion2
      },
      {
        id:3,
        name:"Moran Dhul",
        price:1500,
        image:percussion3
      },
      {
        id:4,
        name:"Cheng Burup",
        price:1800,
        image:percussion4
      },
      {
        id:5,
        name:"Dhutong",
        price:2600,
        image:percussion5
      }

    ],

    wind:[

      {
        id:1,
        name:"Pepa",
        price:1200,
        image:wind1
      },

      {
        id:2,
        name:"Gogona",
        price:1800,
        image:wind2
      },
      {
        id:3,
        name:"Mori Pongsi",
        price:1300,
        image:wind3
      },
      {
        id:4,
        name:"Bahor Hutuli",
        price:900,
        image:wind4
      },
      {
        id:5,
        name:"Mori Tongpo",
        price:1600,
        image:wind5
      },
      {
        id:6,
        name:"Baghdhenu",
        price:2700,
        image:wind6
      }

    ],

    string:[

      {
        id:1,
        name:"Veen",
        price:4200,
        image:string1
      },

      {
        id:2,
        name:"Ektara",
        price:5500,
        image:string2
      },
      {
        id:3,
        name:"Kichokbenu",
        price:5500,
        image:string3
      },
      {
        id:4,
        name:"Jurtang",
        price:5500,
        image:string4
      },
      {
        id:5,
        name:"Krong Chui",
        price:5500,
        image:string5
      },
      {
        id:6,
        name:"Kum Dengdong",
        price:5500,
        image:string6
      },
      {
        id:7,
        name:"Mori Jangkek",
        price:5500,
        image:string7
      }

    ],

    folk:[

      {
        id:1,
        name:"Taal",
        price:2100,
        image:folk1
      },

      {
        id:2,
        name:"Kortal",
        price:700,
        image:folk2
      },
      {
        id:3,
        name:"Hutuli",
        price:700,
        image:folk3
      },
      {
        id:4,
        name:"Daskathiya",
        price:700,
        image:folk4
      },
      {
        id:5,
        name:"Kodital",
        price:700,
        image:folk5
      },
      {
        id:6,
        name:"Saksoni",
        price:700,
        image:folk6
      }

    ]

  };

  const selectedProducts =
  products[type] || [];

  const addToCart = (product) => {

    const cart =
    JSON.parse(localStorage.getItem("cart")) || [];

    cart.push(product);

    localStorage.setItem(
      "cart",
      JSON.stringify(cart)
    );

    alert("Item Added To Cart!");

  };

  return (

    <>

      <Navbar />

      <section className="category-page">

        <div className="category-container">

          <h1>

            {type.charAt(0).toUpperCase() + type.slice(1)} Collection

          </h1>

          <div className="product-grid">

            {
              selectedProducts.map((product)=>(

                <div
                  className="product-card"
                  key={product.id}
                >

                  <img
                    src={product.image}
                    alt={product.name}
                  />

                  <h3>
                    {product.name}
                  </h3>

                  <p>
                    ₹ {product.price}
                  </p>

                  <div className="product-buttons">

                    <button className="shop-btn">
                      Shop Now
                    </button>

                    <button
                      className="cart-btn"

                      onClick={()=>
                        addToCart(product)
                      }
                    >
                      Add To Cart
                    </button>

                  </div>

                </div>

              ))
            }

          </div>

        </div>

      </section>

      {/* <Footer /> */}

    </>

  );
}

export default CategoryPage;