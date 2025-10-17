import { useState, useEffect } from "react";
import "./App.css";

function App() {
	const [services, setServices] = useState([]);
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
				setServices(data);
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
		<div className="App">
			<h1>🔥 Barber Automation System</h1>
			<h2>Available Services</h2>
			<div style={{ display: "grid", gap: "20px", padding: "20px" }}>
				{services.map((service) => (
					<div
						key={service.id}
						style={{
							border: "1px solid #ccc",
							padding: "20px",
							borderRadius: "8px",
						}}
					>
						<h3>{service.name}</h3>
						<p>💰 Price: ${service.price}</p>
						<p>⏱️ Duration: {service.durationInMinutes} minutes</p>
					</div>
				))}
			</div>
		</div>
	);
}

export default App;
