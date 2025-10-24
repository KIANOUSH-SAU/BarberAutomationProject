import { useEffect, useState } from "react";
import BarberCard from "../components/BarberCard";
// Fetch all barbers with their working hours
const AdminPage = () => {
	const [barbers, setBarbers] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	useEffect(() => {
		const token = localStorage.getItem("authToken");
		fetch("/api/BarbersApi", {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		})
			.then((res) => {
				console.log(res);
				if (!res.ok) throw new Error("Failed to fetch barbers");
				return res.json();
			})
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
		<div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
			<div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-5 p-10 flex-1 overflow-auto scrollbar-thin scrollbar-thumb-cyan-400 scrollbar-track-cyan-100 mt-15">
				{barbers.map((barber) => {
					// return <h1 key={barber.id}>{barber.name}</h1>;
					return <BarberCard barber={barber} />;
				})}
			</div>
		</div>
	);
};

export default AdminPage;
