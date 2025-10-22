import ServiceCard from "./ServiceCard";
const Services = ({ services }) => {
	return (
		<div className="services-container h-screen flex flex-col">
			<h1 className="text-large-title">Hizmet Seçimi</h1>
			<div className="grid grid-cols-3 gap-5 p-5 flex-1 overflow-auto scrollbar-thin scrollbar-thumb-cyan-400 scrollbar-track-cyan-100">
				{services.map((service) => (
					<ServiceCard key={service.id} service={service} />
				))}
			</div>
		</div>
	);
};

export default Services;
