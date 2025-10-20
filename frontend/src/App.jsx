import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import ServicesPage from "./pages/ServicesPage";
import AppointmentsPage from "./pages/AppointmentsPage";
import Navbar from "./components/Navbar";

function App() {
	return (
		<Router>
			<Navbar />
			<div className="background min-h-screen">
				<Routes>
					<Route path="/" element={<HomePage />} />
					<Route path="/services" element={<ServicesPage />} />
					<Route
						path="/appointments"
						element={<AppointmentsPage />}
					/>
				</Routes>
			</div>
		</Router>
	);
}

export default App;
