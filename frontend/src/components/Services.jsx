const Services = ({ services }) => {
	return (
		<div className="services-container">
			<h1 className="text-large-title">Hizmet Seçimi</h1>
			<h2 className="text-small-title">Servislerimiz:</h2>
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
						<h3 className="text-small-subtitle">{service.name}</h3>
						<p className="text-small">💰 Price: ${service.price}</p>
						<p className="text-small">
							⏱️ Duration: {service.durationInMinutes} minutes
						</p>
					</div>
				))}
			</div>
		</div>
	);
};

export default Services;
