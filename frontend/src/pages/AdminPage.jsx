import { useEffect, useState } from "react";
// Fetch all barbers with their working hours
const AdminPage = () => {
	const [barbers, setBarbers] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	async function getBarbersWithSchedule() {
		const token = localStorage.getItem("authToken");
		const response = await fetch("https://localhost:7261/api/BarbersApi", {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		});
		if (!response.ok) {
			throw new Error(
				`Failed to fetch barbers: ${response.status} ${response.statusText}`
			);
		}
		const data = await response.json();
		return data;
	}

	useEffect(() => {
		getBarbersWithSchedule()
			.then((data) => {
				console.log(data);
				setBarbers(data);
				setLoading(false);
			})
			.catch((err) => {
				console.error(err);
				setError(err.message);
				setLoading(false);
			});
	}, []);

	if (loading) {
		return <div className="min-h-screen">Loading...</div>;
	}

	if (error) {
		return <div className="min-h-screen">Error: {error}</div>;
	}

	return (
		<div className="min-h-screen max-h-screen">
			{barbers.map((barber) => {
				return <h1 key={barber.id}>{barber.name}</h1>;
			})}
		</div>
	);
};

export default AdminPage;
