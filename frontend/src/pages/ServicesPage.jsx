import { useState, useEffect } from "react";
import Services from "../components/Services";
import { Link } from "react-router-dom";

const ServicesPage = () => {
	const [servicesData, setServicesData] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	useEffect(() => {
		fetch("/api/ServicesApi")
			.then((res) => {
				if (!res.ok) throw new Error("Failed to fetch services");
				return res.json();
			})
			.then((data) => {
				setServicesData(data);
				setLoading(false);
			})
			.catch((err) => {
				setError(err.message);
				setLoading(false);
			});
	}, []);

	if (loading)
		return (
			<div className="min-h-screen flex items-center justify-center">
				<h1 className="text-4xl text-amber-800">Loading...</h1>
			</div>
		);

	if (error)
		return (
			<div className="min-h-screen flex items-center justify-center">
				<h1 className="text-4xl text-red-600">Error: {error}</h1>
			</div>
		);

	return (
		<>
			<nav className="bg-amber-900 text-white p-4">
				<Link to="/" className="hover:text-amber-200">
					← Back to Home
				</Link>
			</nav>
			<Services services={servicesData} />
		</>
	);
};

export default ServicesPage;
