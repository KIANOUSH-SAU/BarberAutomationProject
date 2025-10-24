import { useState, useEffect } from "react";
import Services from "../components/Services";

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
				console.log(data);
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
			<Services services={servicesData} />
		</>
	);
};

export default ServicesPage;
