import ServiceCard from "./ServiceCard";
const Services = ({ services }) => {
	return (
		<div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
			<div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-5 p-10 flex-1 overflow-auto scrollbar-thin scrollbar-thumb-cyan-400 scrollbar-track-cyan-100">
				{services.map((service) => (
					<ServiceCard key={service.id} service={service} />
				))}
			</div>
		</div>
	);
};

export default Services;
