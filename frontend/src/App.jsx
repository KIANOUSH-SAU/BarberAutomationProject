import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import ServicesPage from "./pages/ServicesPage";
import AppointmentsPage from "./pages/AppointmentsPage";
import EmployeesPage from "./pages/EmployeesPage";
import ServicesManagement from "./pages/ServicesManagement";
import ServiceEditPage from "./pages/ServiceEditPage";
import LoginPage from "./pages/LoginPage";
import AdminPage from "./pages/AdminPage";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";

function App() {
	return (
		<Router>
			<div className="background min-h-screen">
				<Navbar />
				<Routes>
					<Route path="/" element={<HomePage />} />
					<Route path="/services" element={<ServicesPage />} />
					<Route
						path="/appointments"
						element={<AppointmentsPage />}
					/>
					<Route path="/admin" element={<AdminPage />} />
					<Route path="/login" element={<LoginPage />} />
					<Route path="/employees" element={<EmployeesPage />} />
					<Route path="/service-edit" element={<ServiceEditPage />} />
					<Route
						path="/services-management"
						element={<ServicesManagement />}
					/>
				</Routes>
				<Footer />
			</div>
		</Router>
	);
}

export default App;
