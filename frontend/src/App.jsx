import { useState, useEffect } from "react";
import Services from "./components/Services";

function App() {
	const [servicesData, setServicesData] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	useEffect(() => {
		// This will be proxied to https://localhost:7261/api/ServicesApi
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
			<div className="App">
				<h1>Loading...</h1>
			</div>
		);
	if (error)
		return (
			<div className="App">
				<h1>Error: {error}</h1>
			</div>
		);

	return (
		<>
			<Services services={servicesData} />
		</>
	);
}

export default App;
