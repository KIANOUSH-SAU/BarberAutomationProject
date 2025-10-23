import { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
	const [isPasswordVisible, setIsPasswordVisible] = useState(false);
	const navigate = useNavigate();
	const emailRef = useRef();
	const passwordRef = useRef();
	// Login function
	async function login(email, password) {
		const response = await fetch("https://localhost:7261/api/auth/login", {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify({ email, password }),
		});

		const data = await response.json();

		if (response.ok) {
			// Store token in localStorage
			localStorage.setItem("authToken", data.token);
			localStorage.setItem(
				"user",
				JSON.stringify({
					email: data.email,
					firstName: data.firstName,
					lastName: data.lastName,
				})
			);
			navigate("/admin");
		}
	}

	// Use token in API calls
	async function getServices() {
		const token = localStorage.getItem("authToken");

		const response = await fetch("https://localhost:7261/api/services", {
			headers: {
				Authorization: `Bearer ${token}`,
			},
		});

		return response.json();
	}
	function handleSubmit(e) {
		e.preventDefault();
		try {
			login(emailRef.current.value, passwordRef.current.value);
		} catch (error) {
			console.log("Problems with the login function:" + error);
		}
	}

	function togglePasswordVisibility() {
		setIsPasswordVisible((prevState) => !prevState);
	}

	return (
		<div className="simple-dark-bg">
			<div className="relative z-10 glass-bg rounded-3xl p-20 max-w-3xl mx-4">
				<h1 className="text-4xl font-bold text-white mb-4 drop-shadow-lg">
					Giriş
				</h1>
				<form onSubmit={handleSubmit}>
					<div>
						<label
							htmlFor="input-group-1"
							className="block text-sm font-medium text-gray-900 dark:text-white mb-3"
						>
							E-postanız:
						</label>
						<div className="relative mb-6">
							<div className="absolute inset-y-0 start-0 flex items-center ps-3.5 pointer-events-none">
								<svg
									className="w-4 h-4 text-gray-500 dark:text-gray-400"
									aria-hidden="true"
									xmlns="http://www.w3.org/2000/svg"
									fill="currentColor"
									viewBox="0 0 20 16"
								>
									<path d="m10.036 8.278 9.258-7.79A1.979 1.979 0 0 0 18 0H2A1.987 1.987 0 0 0 .641.541l9.395 7.737Z" />
									<path d="M11.241 9.817c-.36.275-.801.425-1.255.427-.428 0-.845-.138-1.187-.395L0 2.6V14a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V2.5l-8.759 7.317Z" />
								</svg>
							</div>
							<input
								id="input-group-1"
								type="text"
								className="bg-gray-700 border text-sm rounded-lg block w-full ps-10 p-2.5
							border-gray-600 dark:placeholder-gray-400 text-white"
								placeholder="e-posta@ornek.com"
								ref={emailRef}
							/>
						</div>

						<label
							htmlFor="input-group-2"
							className="block text-sm font-medium text-gray-900 dark:text-white mb-3"
						>
							Şifreniz:
						</label>
						<div className="relative mb-6">
							<div className="absolute inset-y-0 start-0 flex items-center ps-3.5 pointer-events-none">
								<svg
									className="w-5 h-5 text-gray-500 dark:text-gray-400"
									aria-hidden="true"
									xmlns="http://www.w3.org/2000/svg"
									fill="none"
									viewBox="0 0 24 24"
								>
									<path
										stroke="currentColor"
										strokeLinecap="round"
										strokeLinejoin="round"
										strokeWidth="2"
										d="M12 14v3m-3-6V7a3 3 0 0 1 3-3h.01a3 3 0 0 1 3 3v1m-6 0h6m-6 3H9a2 2 0 0 0-2 2v4a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2v-4a2 2 0 0 0-2-2h-3"
									/>
								</svg>
							</div>
							<input
								id="input-group-2"
								type={isPasswordVisible ? "text" : "password"}
								className="bg-gray-700 border text-sm rounded-lg block w-full ps-10 p-2.5
							border-gray-600 dark:placeholder-gray-400 text-white"
								placeholder="•••••••••"
								ref={passwordRef}
							/>
							<div className="absolute inset-y-0 end-0 flex items-center pe-3.5">
								<button
									type="button"
									onClick={togglePasswordVisibility}
									className="text-gray-500 dark:text-gray-400 hover:text-gray-900 dark:hover:text-white"
								>
									{isPasswordVisible ? (
										<svg
											className="w-5 h-5"
											fill="none"
											stroke="currentColor"
											viewBox="0 0 24 24"
											xmlns="http://www.w3.org/2000/svg"
										>
											<path
												strokeLinecap="round"
												strokeLinejoin="round"
												strokeWidth="2"
												d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.879 9.879l4.242 4.242M9.879 9.879L6 6m.375 0l-.375-.375M21 12a9.97 9.97 0 01-1.563 3.029M21 12c0-4.478-3.79-7-8.457-7a9.97 9.97 0 00-3.029 1.563"
											></path>
										</svg>
									) : (
										<svg
											className="w-5 h-5"
											fill="none"
											stroke="currentColor"
											viewBox="0 0 24 24"
											xmlns="http://www.w3.org/2000/svg"
										>
											<path
												strokeLinecap="round"
												strokeLinejoin="round"
												strokeWidth="2"
												d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
											></path>
											<path
												strokeLinecap="round"
												strokeLinejoin="round"
												strokeWidth="2"
												d="M2.458 12C3.732 7.943 7.522 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.478 0-8.268-2.943-9.542-7z"
											></path>
										</svg>
									)}
								</button>
							</div>
						</div>
					</div>
					<div className="text-center">
						<button type="submit" class="btn-type-3 justify-center">
							Giriş Yap
						</button>
					</div>
				</form>
				<div className="space-x-4"></div>
			</div>
		</div>
	);
};

export default LoginPage;
