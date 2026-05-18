import "../styles/categories.css";

import { Link } from "react-router-dom";

import Percussion from "../assets/Percussion.jpg";
import Wind from "../assets/Wind.jpg";
import Other from "../assets/Other.jpg";
import Accessories from "../assets/Accessories.jpg";

function Categories() {

    const data = [

        {
            title: "Percussion",
            image: Percussion,
            route: "/category/percussion"
        },

        {
            title: "Wind Instruments",
            image: Wind,
            route: "/category/wind"
        },

        {
            title: "String Instruments",
            image: Other,
            route: "/category/string"
        },

        {
            title: "Folk & Tribal",
            image: Accessories,
            route: "/category/folk"
        },

    ];

    return (

        <section className="categories" id="shop">

            <h1>Shop by Category</h1>
            <div className="category-container">
                {
                    data.map((item,index)=>(
                        <Link to={item.route} className="category-link" key={index} >
                            <div className="card">
                                <div className="image-box">
                                    <img src={item.image} alt=""/>
                                </div>
                                <h2>{item.title}</h2>
                            </div>
                        </Link>
                    ))
                }
            </div>
        </section>
    );
}

export default Categories;