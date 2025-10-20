import ServiceCard from "./ServiceCard";
const Services = ({ services }) => {
	return (
		<div className="services-container h-screen flex flex-col">
			<h1 className="text-large-title">Hizmet Seçimi</h1>
			<div className="grid grid-cols-3 gap-5 p-5 flex-1 overflow-auto">
				{services.map((service) => (
					<ServiceCard key={service.id} service={service} />
				))}
			</div>
		</div>
	);
};

export default Services;
