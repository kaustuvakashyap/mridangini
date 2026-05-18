import { useState, useEffect } from "react";
import "../styles/sellerDashboard.css";

function SellerDashboard() {
    const user = JSON.parse(localStorage.getItem("user"));

    const [product, setProduct] =
        useState({
            title: "",
            description: "",
            price: "",
            category: "percussion",
            image: ""
        });

    const [sellerProducts, setSellerProducts] = useState([]);
    const [sellerOrders, setSellerOrders] = useState([]);

    useEffect(() => {
        const currentUser = JSON.parse(localStorage.getItem("user"));
        const allProducts = JSON.parse(localStorage.getItem("products")) || [];

        const filteredProducts = allProducts.filter((item) => item.sellerEmail === currentUser.email);

        setSellerProducts(filteredProducts);

        const allOrders = JSON.parse(localStorage.getItem("orders")) || [];
        const sellerRelatedOrders = allOrders.filter((order) =>
                order.items.some((item) =>
                        item.sellerEmail === currentUser.email
                )
            );

        setSellerOrders(sellerRelatedOrders);

    }, []);

    const totalProducts = sellerProducts.length;
    const totalOrders = sellerOrders.length;
    const pendingOrders = sellerOrders.filter((order) => order.status === "Pending").length;
    const deliveredOrders = sellerOrders.filter((order) => order.status === "Delivered").length;
    const totalRevenue = sellerOrders.reduce((total, order) => total + Number(order.total),0);

    function handleChange(e) {
        setProduct({...product, [e.target.name]: e.target.value});
    }

    function handleImage(e) {
        const file = e.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setProduct({...product, image: reader.result});
            };
            reader.readAsDataURL(file);
        }
    }

    function handleAddProduct(e) {
        e.preventDefault();

        const existingProducts = JSON.parse(localStorage.getItem("products")) || [];
        const currentUser = JSON.parse(localStorage.getItem("user"));

        const newProduct = {
            ...product,
            id: Date.now(),
            sellerName: currentUser.name,
            sellerEmail: currentUser.email
        };

        existingProducts.push(newProduct);

        localStorage.setItem("products",JSON.stringify(existingProducts));

        setSellerProducts((prev) =>
            [
                ...prev,
                newProduct
            ]);

        alert("Product Added!");

        setProduct({
            title: "",
            description: "",
            price: "",
            category: "percussion",
            image: ""
        });
    }

    function deleteProduct(id) {
        const updatedProducts = sellerProducts.filter((item) =>item.id !== id);
        setSellerProducts([...updatedProducts]);
        const allProducts = JSON.parse(localStorage.getItem("products")) || [];
        const remainingProducts = allProducts.filter((item) => item.id !== id);
        localStorage.setItem("products",JSON.stringify(remainingProducts));
    }

    return (

        <section className="seller-dashboard">
            <div className="seller-header">
                <h1> Seller Dashboard</h1>
                <p> Welcome, {" "} {user?.name}</p>
            </div>

            {/* ANALYTICS */}

            <div className="analytics-grid">
                <div className="analytics-card">
                    <h2> {totalProducts}</h2>
                    <p> Total Products</p>
                </div>
                <div className="analytics-card">
                    <h2> {totalOrders}</h2>
                    <p> Total Orders</p>
                </div>
                <div className="analytics-card">
                    <h2> {pendingOrders} </h2>
                    <p> Pending Orders </p>
                </div>
                <div className="analytics-card">
                    <h2> {deliveredOrders} </h2>
                    <p> Delivered Orders </p>
                </div>
                <div className="analytics-card revenue-card">
                    <h2>₹ {totalRevenue}</h2>
                    <p>Revenue</p>
                </div>
            </div>

            {/* PRODUCT FORM */}

            <form className="product-form" onSubmit={handleAddProduct}>

                <input type="text" placeholder="Product Title"                     
                    name="title"
                    value={product.title}
                    onChange={handleChange}
                    required
                />

                <textarea
                    placeholder="Product Description"
                    name="description"
                    value={product.description}
                    onChange={handleChange}
                    required
                />

                <input
                    type="number"
                    placeholder="Price"
                    name="price"
                    value={product.price}
                    onChange={handleChange}
                    required
                />

                <select name="category" value={product.category} onChange={handleChange}>
                    <option value="percussion">Percussion</option>
                    <option value="wind">Wind Instruments</option>
                    <option value="string">String Instruments</option>
                    <option value="folk">Folk & Tribal</option>
                </select>

                <label className="custom-file-upload"> Upload Product Image
                    <input
                        type="file"
                        accept="image/*"
                        onChange={handleImage}
                        required
                    />
                </label>

                {
                    product.image && <img src={product.image} alt="preview" className="preview-image"/>
                }

                <button type="submit"> Add Product </button>
            </form>

            {/* SELLER PRODUCTS */}

            <div className="seller-products">
                <h2> Your Listed Products</h2>
                <div className="seller-product-grid">
                    {
                        sellerProducts.map((item) => (
                            <div className="seller-product-card" key={item.id}>

                                <img src={item.image} alt=""/>

                                <div className="seller-product-content">
                                    <h3>{item.title}</h3>
                                    <p>₹ {item.price}</p>
                                    <span>{item.category}</span>
                                    <button className="delete-product-btn" onClick={() => deleteProduct(item.id)}>
                                        Delete Product
                                    </button>
                                </div>
                            </div>
                        ))
                    }
                </div>
            </div>
        </section>
    );
}

export default SellerDashboard;