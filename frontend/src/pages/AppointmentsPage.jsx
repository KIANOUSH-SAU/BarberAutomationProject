import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";

const AppointmentsPage = () => {
	const location = useLocation();
	const [services, setServices] = useState([]);
	const [loading, setLoading] = useState(true);
	const [error, setError] = useState(null);

	// State for form inputs
	const [name, setName] = useState("");
	const [phone, setPhone] = useState("");
	const [selectedService, setSelectedService] = useState(
		location.state?.service?.id || ""
	);
	// For a standard date input, it's better to store the date as a string in 'YYYY-MM-DD' format
	const [appointmentDate, setAppointmentDate] = useState(
		new Date().toISOString().split("T")[0]
	);

	useEffect(() => {
		fetch("/api/ServicesApi")
			.then((res) => {
				if (!res.ok) {
					throw new Error(
						"Network response was not ok while fetching services."
					);
				}
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

	const handleSubmit = (e) => {
		e.preventDefault();
		const appointmentData = {
			name,
			phone,
			serviceId: selectedService,
			appointmentDate,
		};
		console.log("Booking appointment:", appointmentData);
		// Here you would typically send the data to your backend API
	};

	return (
		<div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
			<div className="w-full max-w-2xl mx-auto bg-white rounded-2xl shadow-2xl p-8 md:p-12 mt-15">
				<h1 className="text-3xl md:text-4xl font-bold text-gray-800 mb-2 text-center">
					Kolay Randevu Al
				</h1>
				<p className="text-gray-500 mb-8 text-center">
					İstediğiniz servisi ve randevu tarihini seçiniz
				</p>

				{loading && (
					<div className="text-center text-gray-500">
						Yükleniyor...
					</div>
				)}
				{error && (
					<div className="text-center text-red-500">
						Hata: {error}
					</div>
				)}

				{!loading && !error && (
					<form onSubmit={handleSubmit} className="space-y-6">
						<div className="flex justify-between">
							<div className="w-2/5">
								<label
									htmlFor="name"
									className="block mb-2 text-sm font-medium text-gray-700"
								>
									Adınız:
								</label>
								<input
									id="name"
									type="text"
									placeholder="KIANOUSH"
									required
									value={name}
									onChange={(e) => setName(e.target.value)}
									className="w-full px-4 py-2 bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500"
								/>
							</div>
							<div className="w-2/5">
								<label
									htmlFor="name"
									className="block mb-2 text-sm font-medium text-gray-700"
								>
									Soyadınız:
								</label>
								<input
									id="name"
									type="text"
									placeholder="SEDDIGHPOUR"
									required
									value={name}
									onChange={(e) => setName(e.target.value)}
									className="w-full px-4 py-2 bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500"
								/>
							</div>
						</div>
						<div>
							<label
								htmlFor="phone"
								className="block mb-2 text-sm font-medium text-gray-700"
							>
								Telefon Numaranız:
							</label>
							<input
								id="phone"
								type="tel"
								placeholder="+90 555 555 5555"
								required
								value={phone}
								onChange={(e) => setPhone(e.target.value)}
								className="w-full px-4 py-2 bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500"
							/>
						</div>
						<div>
							<label
								htmlFor="service"
								className="block mb-2 text-sm font-medium text-gray-700"
							>
								Seçilen Servis:
							</label>
							<select
								id="service"
								required
								value={selectedService}
								onChange={(e) =>
									setSelectedService(e.target.value)
								}
								className="w-full px-4 py-2 bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500"
							>
								<option value="" disabled>
									Servis Seçiniz
								</option>
								{services.map((service) => (
									<option key={service.id} value={service.id}>
										{service.name} - {service.price}TL
									</option>
								))}
							</select>
						</div>
						<div>
							<label
								htmlFor="date"
								className="block mb-2 text-sm font-medium text-gray-700"
							>
								Randevu Tarihi
							</label>
							<input
								id="date"
								type="date"
								min={new Date().toISOString().split("T")[0]}
								value={appointmentDate}
								onChange={(e) =>
									setAppointmentDate(e.target.value)
								}
								className="w-full px-4 py-2 bg-gray-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500"
							/>
						</div>
						<button
							type="submit"
							className="btn-type-1"
							style={{
								borderRadius: "10px",
							}}
						>
							Randevu Al
						</button>
					</form>
				)}
			</div>
		</div>
	);
};

export default AppointmentsPage;
