import { SERVICE_IMAGES } from "../assets/assetsHandler";
import { Link } from "react-router-dom";

const ServiceCard = ({ service, isAdmin }) => {
	return (
		<div className="max-w-sm border border-red-700 rounded-lg shadow-sm bg-blue-950">
			<a href="#">
				<img
					className="rounded-t-lg p-10 bg-white"
					src={SERVICE_IMAGES[service.id - 1]}
					alt=""
				/>
			</a>
			<div className="p-5">
				<a href="#">
					<h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
						{service.name}
					</h5>
				</a>

				<div className="flex gap-8">
					<p className="mb-3 font-normal text-gray-700 dark:text-gray-400">
						{service.durationInMinutes + " Dakika"}
					</p>
					<p className="mb-3 font-normal text-gray-700 dark:text-gray-400">
						{service.price + "TL"}
					</p>
				</div>

				<div className="justify-self-between justify-center mt-4">
					{isAdmin ? (
						<div className="flex gap-4 justify-self-end">
							<Link
								to="/service-edit"
								className="btn-type-2"
								style={{ width: "100px" }}
								state={{ service }}
							>
								Düzenle
							</Link>
							<button
								className="btn-type-1"
								style={{
									width: "100px",
								}}
							>
								Sil
							</button>
						</div>
					) : (
						<Link
							to="/appointments"
							className="btn-type-1 gap-2 inline-flex"
							style={{
								width: "150px",
							}}
							state={{ service }}
						>
							<p> Randevu Al</p>
							<svg
								className="rtl:rotate-180 w-3.5 h-3.5 ms-2"
								aria-hidden="true"
								xmlns="http://www.w3.org/2000/svg"
								fill="none"
								viewBox="0 0 14 10"
							>
								<path
									stroke="white"
									strokeLinecap="round"
									strokeLinejoin="round"
									strokeWidth="2"
									d="M1 5h12m0 0L9 1m4 4L9 9"
								/>
							</svg>
						</Link>
					)}
				</div>
			</div>
		</div>
	);
};

export default ServiceCard;
