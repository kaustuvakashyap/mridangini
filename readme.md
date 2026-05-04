# E-Commerce Platform Core Architecture

## 1. Project Goal
The primary goal is to build a fully deployable, high-performance E-commerce platform that provides a seamless shopping experience for customers and robust management tools for administrators.

## 2. System Architecture & Tech Stack
This system utilizes an N-tier architecture to support scalability and enforce a strict separation of concerns.

* **Backend Development:** Django (Python)
* **Frontend Development:** Vanilla HTML, CSS, and JavaScript
* **Design & Prototyping:** Figma
* **Methodology:** Rapid Application Development (RAD) & Evolutionary Model

## 3. Local Environment Setup

### Prerequisites
* Python 3.10+
* Node.js (for potential frontend tooling/minification)
* PostgreSQL or SQLite (depending on current phase)



## 4. Development Phases & Timeline

* **Phase 0: Setup & Planning (May 6)** - Repo setup, tech stack, DB schema, API contracts.
* **Phase 1: Core MVP (May 7-10)** - Product catalog, search, cart, basic checkout.
* **Phase 2: Integration & Payments (May 11-13)** - Payment gateway, order system, email notifications.
* **Phase 3: Admin Dashboard (May 14-16)** - Inventory CRUD, order tracking, invoices.
* **Phase 4: Stabilization (May 17-18)** - Bug fixing, optimization, security.
* **Phase 5: Deployment (May 19-20)** - Final testing, hosting, responsiveness.

## 5. Team Directory and Responsibilities

* **Design:** Gargee Kakaty (Lead), Kaustuva Kashyap
* **Frontend:** Abhishek Das (Lead), Gargee Kakaty
* **Backend:** Ronit Choudhury (Co-Dev), Abhishek Das (Co-Dev)
* **Documentation:** Ronit Choudhury (Lead)

## 6. Future Enhancements & Algorithmic Notes

### Microservice Transformation
The monolithic core will eventually be refactored into independent microservices, containerized using Docker, and orchestrated via Kubernetes to achieve linear scalability and fault isolation.

### Dynamic Pricing Module
Future iterations will introduce behavior-driven and demand-based price adjustments. The backend logic will calculate the Price Elasticity of Demand using the following formula:

$$E_d = \frac{\% \Delta Q}{\% \Delta P}$$

Where $E_d$ represents elasticity, $\% \Delta Q$ is the percentage change in quantity demanded, and $\% \Delta P$ is the percentage change in price. The API will query the temporal rate of inventory depletion against site traffic to programmatically optimize $P$ for maximum revenue yield.