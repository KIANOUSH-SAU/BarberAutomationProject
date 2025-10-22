import { IMAGES } from "../assets/assetsHandler";
import { Link } from "react-router-dom";

const ServiceCard = ({ service }) => {
	return (
		<div className="max-w-sm bg-white border border-gray-200 rounded-lg shadow-sm service-glass-bg">
			<a href="#">
				<img
					className="rounded-t-lg p-10 bg-amber-100"
					src={IMAGES[service.id - 1]}
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
				<div className="justify-self-end justify-center">
					<Link
						to="/appointments"
						className="glass-btn-2 inline-flex gap-2"
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
								stroke="red"
								strokeLinecap="round"
								strokeLinejoin="round"
								strokeWidth="2"
								d="M1 5h12m0 0L9 1m4 4L9 9"
							/>
						</svg>
					</Link>
				</div>
			</div>
		</div>
	);
};

export default ServiceCard;
