import { useState, useEffect } from "react";
import "./App.css";

function App() {
	const [data, setData] = useState(null);
	const [loading, setLoading] = useState(true);

	useEffect(() => {
		// This will be proxied to https://localhost:5001/api/test during development
		fetch("/api/test")
			.then((res) => res.json())
			.then((data) => {
				setData(data);
				setLoading(false);
			})
			.catch((err) => {
				console.error("API call failed:", err);
				setLoading(false);
			});
	}, []);

	return (
		<div className="App">
			<h1>Barber Automation - React Frontend</h1>
			{loading ? (
				<p>Loading...</p>
			) : (
				<pre>{JSON.stringify(data, null, 2)}</pre>
			)}
		</div>
	);
}

export default App;
