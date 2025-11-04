import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { SERVICE_IMAGES } from "../assets/assetsHandler";

const ServiceEditPage = () => {
	const location = useLocation();
	const [selectedService, setSelectedService] = useState(
		location.state?.service || ""
	);

	const handleUpdate = () => {};
	return (
		<div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
			<div className="w-full max-w-2xl mx-auto bg-blue-950 rounded-2xl shadow-2xl p-8 md:p-12 mt-15">
				<div className="w-full rounded-lg shadow-sm bg-blue-950 flex flex-col md:flex-row gap-6">
					<div className="flex-shrink-0">
						<img
							className="rounded-lg p-10 bg-white w-full md:w-sm"
							src={SERVICE_IMAGES[selectedService.id - 1]}
							alt=""
						/>
					</div>
					<div className="flex-1 flex flex-col justify-start">
						<input
							id="name"
							type="text"
							placeholder={selectedService.name}
							required
							value={selectedService.name}
							onChange={(e) =>
								setSelectedService({
									...selectedService,
									name: e.target.value,
								})
							}
							className="w-full px-4 py-2 bg-gray-50 border
                            border-gray-300 text-gray-900 rounded-lg 
                            focus:ring-blue-500 focus:border-blue-500"
						/>
						<input
							id="duration"
							type="text"
							placeholder={
								selectedService.durationInMinutes + " Dakika"
							}
							required
							value={selectedService.durationInMinutes}
							onChange={(e) =>
								setSelectedService({
									...selectedService,
									durationInMinutes: e.target.value,
								})
							}
							className="w-full px-4 py-2 
                            bg-gray-50 border border-gray-300
                            text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500 mt-2"
						/>
						<input
							id="price"
							type="text"
							placeholder={selectedService.price + " TL"}
							required
							value={selectedService.price}
							onChange={(e) =>
								setSelectedService({
									...selectedService,
									price: e.target.value,
								})
							}
							className="w-full px-4 py-2 
                            bg-gray-50 border border-gray-300 
                            text-gray-900 rounded-lg focus:ring-blue-500 focus:border-blue-500 mt-2"
						/>
					</div>
				</div>
				<button
					className="mt-4 w-full px-4 py-2 bg-blue-500 text-white rounded-lg
                        hover:bg-blue-600 cursor-pointer"
					onClick={handleUpdate}
				>
					Güncelle
				</button>
			</div>
		</div>
	);
};

export default ServiceEditPage;
