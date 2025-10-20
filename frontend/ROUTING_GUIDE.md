# React Router - Multiple Pages Setup

## ✅ What I've Set Up For You

### Pages Created:

1. **HomePage** (`/`) - Landing page with links to other pages
2. **ServicesPage** (`/services`) - Shows all barbershop services
3. **AppointmentsPage** (`/appointments`) - Booking form

### How It Works:

#### App.jsx - Main Router Configuration

```jsx
<Router>
	<Routes>
		<Route path="/" element={<HomePage />} />
		<Route path="/services" element={<ServicesPage />} />
		<Route path="/appointments" element={<AppointmentsPage />} />
	</Routes>
</Router>
```

## 🚀 How to Navigate Between Pages

### Method 1: Using `Link` Component (Recommended)

```jsx
import { Link } from "react-router-dom";

<Link to="/services">Go to Services</Link>
<Link to="/appointments">Book Now</Link>
<Link to="/">Home</Link>
```

### Method 2: Programmatic Navigation

```jsx
import { useNavigate } from "react-router-dom";

function MyComponent() {
	const navigate = useNavigate();

	const goToServices = () => {
		navigate("/services");
	};

	return <button onClick={goToServices}>View Services</button>;
}
```

### Method 3: URL Parameters

```jsx
// Define route with parameter
<Route path="/service/:id" element={<ServiceDetail />} />

// Navigate with parameter
<Link to="/service/123">Service 123</Link>

// Access parameter in component
import { useParams } from "react-router-dom";

function ServiceDetail() {
  const { id } = useParams();
  return <div>Service ID: {id}</div>;
}
```

## 📁 Folder Structure

```
src/
├── pages/           ← Your page components
│   ├── HomePage.jsx
│   ├── ServicesPage.jsx
│   └── AppointmentsPage.jsx
├── components/      ← Reusable components
│   ├── Services.jsx
│   └── ServiceCard.jsx
├── App.jsx          ← Router setup
└── main.jsx         ← Entry point
```

## 🎯 Adding More Pages

### Step 1: Create a new page component

```jsx
// src/pages/AboutPage.jsx
const AboutPage = () => {
	return (
		<div>
			<h1>About Us</h1>
			<p>Welcome to our barber shop!</p>
		</div>
	);
};

export default AboutPage;
```

### Step 2: Add route in App.jsx

```jsx
import AboutPage from "./pages/AboutPage";

<Route path="/about" element={<AboutPage />} />;
```

### Step 3: Link to it from anywhere

```jsx
<Link to="/about">About Us</Link>
```

## 🔗 Common Routes You Might Need

```jsx
<Route path="/" element={<HomePage />} />
<Route path="/services" element={<ServicesPage />} />
<Route path="/services/:id" element={<ServiceDetail />} />
<Route path="/appointments" element={<AppointmentsPage />} />
<Route path="/appointments/confirm" element={<ConfirmPage />} />
<Route path="/about" element={<AboutPage />} />
<Route path="/contact" element={<ContactPage />} />
<Route path="*" element={<NotFoundPage />} />  {/* 404 page */}
```

## 🎨 Navigation Bar Example

```jsx
import { Link } from "react-router-dom";

const Navbar = () => {
	return (
		<nav className="bg-amber-900 text-white p-4">
			<div className="container mx-auto flex gap-6">
				<Link to="/" className="hover:text-amber-200">
					Home
				</Link>
				<Link to="/services" className="hover:text-amber-200">
					Services
				</Link>
				<Link to="/appointments" className="hover:text-amber-200">
					Book Now
				</Link>
				<Link to="/about" className="hover:text-amber-200">
					About
				</Link>
			</div>
		</nav>
	);
};
```

## 📍 Active Link Styling

```jsx
import { NavLink } from "react-router-dom";

<NavLink
	to="/services"
	className={({ isActive }) =>
		isActive ? "text-amber-200 font-bold" : "text-white"
	}
>
	Services
</NavLink>;
```

## 🚦 Current Routes in Your App

-   **`/`** → Home page (landing with navigation)
-   **`/services`** → Shows all services from API
-   **`/appointments`** → Booking form

Navigate in your browser:

-   `http://localhost:5173/`
-   `http://localhost:5173/services`
-   `http://localhost:5173/appointments`

## 💡 Tips

1. Use `<Link>` instead of `<a>` tags for internal navigation
2. Use `useNavigate()` for programmatic navigation (after form submit, etc.)
3. Use `useParams()` to read URL parameters
4. Use `useLocation()` to get current URL info
5. Create a shared Layout component for common elements (navbar, footer)

---

**Your app now has multiple pages! 🎉**
